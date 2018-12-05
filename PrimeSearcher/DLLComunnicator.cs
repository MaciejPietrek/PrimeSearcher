using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace PrimeSearcher
{
    unsafe class DLLComunnicator
    {
        [DllImport("PrimeSearcherASM.dll", CallingConvention = CallingConvention.StdCall)]
            private static extern int return1();
        

        public static int usingASMLicz()
        {
            return return1();
        }


    }
}
