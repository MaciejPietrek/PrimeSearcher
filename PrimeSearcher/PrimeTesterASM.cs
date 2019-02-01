using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSearcher
{
    public class PrimeTesterASM : iTester
    {

        [DllImport("PrimeSearcherASM.dll", CallingConvention = CallingConvention.StdCall)]
            private static extern int isPrime(int number);

        public bool IsPrime(int number)
        {
            if (isPrime(number) == 1)
                return true;
            else
                return false;
        }
    }
}
