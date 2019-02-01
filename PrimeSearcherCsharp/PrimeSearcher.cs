using System;

namespace PrimeSearcherCsharp
{
    public class PrimeSearcher
    {
        public int isPrime(int number)
        {
            int wynik_dzielenia = number;

            if (number == 2)
                return 1;

            for (int i = 2; i <= wynik_dzielenia; i++)
            {
                if (number % i == 0)
                    return 0;
                wynik_dzielenia = number / i;
            }
            return 1;
        }
    }
}
