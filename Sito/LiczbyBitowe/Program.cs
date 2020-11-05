using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiczbyBitowe
{
    class Program
    {
       static long sum = 0;


        static void Main(string[] args)
        {

            Stopwatch stopwatch = Stopwatch.StartNew();
            ChceckBit();
            stopwatch.Stop();
            double proc = stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine(proc + "ms");
            Console.WriteLine("suma " + sum);
            
            Console.Read();

           

        }


        static void ChceckBit()
        {
            int bit;
            int AND1;
            int AND2;
            for (int j, i = 0; i < 31; i++)
            {
                AND1 = 1 << i;
                for (j = i + 1; j < 31; j++)
                {
                    AND2 = 1 << j;
                    bit = AND1 | AND2;
                    sum += bit;
                }

            }

        }
    }
}
