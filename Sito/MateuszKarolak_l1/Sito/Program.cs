using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sito
{
    class Program
    { 
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            long sum = 0;
            BitArray bit = new BitArray(70000000, false);
                Sito(bit);
            stopwatch.Stop();
            double proc = stopwatch.ElapsedMilliseconds;
            Console.WriteLine(proc);
            for (int i = 2; i < 70000000; i++)
            {
                if (bit[i] == false) sum += i;
            }
            Console.WriteLine(sum);
            Console.Read();
        }

        public static void Sito(BitArray NotPrioeNumber)
        {
            for (int i = 2; i * i <= 70000000; i++)
            {
                if (NotPrioeNumber[i] == false)
                {
                    for (int j = i * i; j < 70000000; j += i)
                        NotPrioeNumber[j] = true;
                }
            }
        }

    }
}
