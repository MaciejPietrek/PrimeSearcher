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
        [DllImport("PrimeSearcherASM.dll", CallingConvention = CallingConvention.StdCall)]
            private static extern int isPrime(int number);

        Mutex indexMutex;

        int index;

        int lowerBound;
        int upperBound;
        int intigerNumber;
        int maxThreadNumber;

        List<Task> taskList;

        int[] intigerArray;
        bool[] resultArray;

        public Searcher(int lowerBound, int upperBound, int maxThreadNumber, PrimeTester tester)
        {
            this.indexMutex = new Mutex(false);

            this.index = 0;

            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
            this.intigerNumber = upperBound - lowerBound + 1;
            this.maxThreadNumber = maxThreadNumber;
            
            this.taskList = new List<Task>();

            this.intigerArray = new int[this.intigerNumber];
            this.resultArray = new bool[this.intigerNumber];

            for(int index_ = 0; index_ < this.intigerNumber; index_++)
            {
                intigerArray[index_] = index_ + lowerBound;
            }
        }

        void taskJob(int currentIndex)
        {
            int tmp;
            if (indexMutex.WaitOne(Timeout.Infinite))
            {
                if (index + 1 >= intigerNumber)
                {
                    indexMutex.ReleaseMutex();
                    resultArray[currentIndex] = isPrimeNumber(lowerBound + currentIndex);
                }
                else
                {
                    index++;
                    tmp = index;
                    indexMutex.ReleaseMutex();
                    resultArray[currentIndex] = isPrimeNumber(lowerBound + currentIndex);
                    taskJob(tmp);
                }
            }
        }

        public bool[] searchForPrimes()
        {
            int help;
            for(int numberOfThread = 0; numberOfThread < maxThreadNumber; numberOfThread++)
            {
                help = numberOfThread;
                taskList.Add(Task.Factory.StartNew(() => taskJob(help)));
            }
            Task.WaitAll(taskList.ToArray());
            return resultArray;
        }

        public bool isPrimeNumber(int number)
        {

            if (isPrime(number) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}