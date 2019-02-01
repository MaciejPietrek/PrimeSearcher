using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSearcher
{
    class PrimeTesterCsharp : iTester
    {
        static dynamic instance;

        static PrimeTesterCsharp()
        {
            Assembly assembly = Assembly.LoadFrom("PrimeSearcherCsharp.dll");

            Type type = assembly.GetExportedTypes()[0];
            
            instance = Activator.CreateInstance(type);
        }

        public bool IsPrime(int number)
        {
            if (instance.isPrime(number) == 1)
                return true;
            else
                return false;
        }
    }
}
