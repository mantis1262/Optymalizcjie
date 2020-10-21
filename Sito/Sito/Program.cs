using System;
using System.Collections;
using System.Diagnostics;

namespace Sito
{
    class Program
    {

        const int MAX = 70000000;
        const int MAXd2 = 35000000;
        static int max = 0;
        static void Main(string[] args)
        {
            max = (int)Math.Floor(Math.Sqrt(MAX));
            Stopwatch stopwatch = Stopwatch.StartNew();
            long sum = 2;

            BitArray bitArray = new BitArray(MAXd2, false);
            // Sito(bitArray);
            sito2(bitArray);
            stopwatch.Stop();
            double proc = stopwatch.ElapsedMilliseconds;
            Console.WriteLine(proc);
            for (int i = 1; i < MAXd2; i++)
            {
                if (bitArray[i] == false) sum = sum + (2*i+1);
            }
            Console.WriteLine(sum);
            Console.Read();
        }

        //public static void Sito(BitArray NotPrioeNumber)
        //{
        //    for (int i = 2; i <= max; i++)
        //    {
        //        if (NotPrioeNumber[i] == false)
        //        {
        //            for (int j = i * i; j < MAX; j += i)
        //                NotPrioeNumber[j] = true;
        //        }
        //    }
        //}

          public static void sito2(BitArray notPrime)
        {
            int i = 1, p = 3, k;
           for(int q=4; q<MAXd2; i++, p+=2, q+=(p << 1) - 2)
            {
                if (!notPrime[i])
                {
                    k = q;
                    while (k < MAXd2)
                    {
                        notPrime[k] = true; k += p;
                    }
                }

            };
        }

    }
}
