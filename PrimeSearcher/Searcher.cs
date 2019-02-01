using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;

namespace PrimeSearcher
{
    public class Searcher
    {
        Mutex indexMutex;

        List<Task> taskList;
        iTester tester;

        #region OTHER STUFF

        int index;
        readonly int lowerBound;
        readonly int upperBound;
        readonly int intigerNumber;
        readonly int maxThreadNumber;
        bool[] resultArray;
   
        #endregion

        public Searcher(int lowerBound, int upperBound, int maxThreadNumber, iTester tester)
        {
            this.indexMutex         = new Mutex(false);
            this.index              = 0;
            this.lowerBound         = lowerBound;
            this.upperBound         = upperBound;
            this.intigerNumber      = upperBound - lowerBound + 1;
            this.maxThreadNumber    = maxThreadNumber;
            this.taskList           = new List<Task>();
            this.tester             = tester;
            this.resultArray        = new bool[this.intigerNumber];
        }

        void taskJob(int currentIndex)
        {
            while(currentIndex < intigerNumber)
            {
                indexMutex.WaitOne(Timeout.Infinite);
                currentIndex = index;
                index++;
                indexMutex.ReleaseMutex();
                if(currentIndex >= intigerNumber)
                {
                    return;
                }
                resultArray[currentIndex] = IsPrime(lowerBound + currentIndex);
            }
        }

        public bool[] Proceed()
        {
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = maxThreadNumber;

            Parallel.For(0, intigerNumber, options, index =>
            {
                resultArray[index] = IsPrime(lowerBound + index);
            });
            return resultArray;
        }

        public bool IsPrime(int number)
        {
            return tester.IsPrime(number);
        }
    }
}