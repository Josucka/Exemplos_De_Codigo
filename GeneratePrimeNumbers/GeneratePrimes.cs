using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratePrimeNumbers
{
    public class GeneratePrimes
    {
        private static int s;
        private static bool[] f;
        private static int[] primes;

        public static int[] GeneretePrimeNumbers(int maxValue)
        {
            if (maxValue < 2)
                return new int[0];
            else
            {
                InitializeSieve(maxValue);
                Sieve();
                LoadPrimes();
                return primes;
            }
        }

        private static void InitializeSieve(int maxValue)
        {
            s = maxValue + 1;
            f = new bool[s];
            int i;

            for(i = 0; i < s; i++)
                f[i] = true;

            f[0] = f[1] = false;
        }

        private static void Sieve()
        {
            int i;
            int j;
            for(i = 2; i < Math.Sqrt(s) + 1; i++)
            {
                if (f[i])
                {
                    for (j = 2 * i; j < s; j += i)
                        f[j] = false;
                }
            }
        }

        private static void LoadPrimes()
        {
            int i;
            int j;
            int count = 0;
            for(i = 0; i < s; i++)
            {
                if(f[i])
                    count++;
            }

            primes = new int[count];
            for(i = 0, j =0; i < s; i++)
            {
                if (f[i])
                    primes[j++] = i;
            }
        }

        //        int s = maxValue + 1;
        //        bool[] f = new bool[s];
        //        int i;
        //        for(i = 0; i < s; i++)
        //            f[i] = true;

        //        f[i] = false;

        //        int j;
        //        for(i = 2; i < Math.Sqrt(s) + 1; i++)
        //        {
        //            if (f[i])
        //            {
        //                for(j = 2 * i; j < s; j += i)
        //                    f[j] = false;
        //            }
        //        }

        //        int count = 0;
        //        for(i = 0; i < s; i++)
        //        {
        //            if (f[i])
        //                count++;
        //        }

        //        int[] primes = new int[count];
        //        for(i = 0, j = 0; i < s; i++)
        //        {
        //            if (f[i])
        //                primes[j++] = i;
        //        }
        //        return primes;
        //    }
        //    else
        //    {
        //        return new int[0];
        //    }
        //}
    }
}
