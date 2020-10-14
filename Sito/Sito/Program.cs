using System;
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
            ulong sum = 0;
            bool[] NotPrioeNumber = new bool[70000000];
            Sito(NotPrioeNumber);
            stopwatch.Stop();
            double proc = stopwatch.ElapsedMilliseconds;
            Console.WriteLine(proc);
            for (uint i = 2; i < 70000000; i++)
            {
                if (!NotPrioeNumber[i]) sum += i;
            }
            Console.WriteLine(sum);
            GC.Collect();
            Console.Read();
        }

        public static void Sito(bool[] NotPrioeNumber)
        {
            for (uint i = 2; i * i <= 70000000; i++)
            {
                if (!NotPrioeNumber[i])
                {
                    for (uint j = i * i; j < 70000000; j += i)
                        NotPrioeNumber[j] = true;
                }
            }
        }

    }
}
