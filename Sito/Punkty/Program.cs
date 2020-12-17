using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Punkty
{
    class Program
    {
        public struct Punkt
        {
          public float waga;
          public float point;

            public Punkt(float waga, float point)
            {
                this.waga = waga;
                this.point = point;
            }

            public override string ToString()
            {
                return ("{"+ waga + "; "+point +"}");
            }
        }

        static void Main(string[] args)
        {

            const int N = 30;
            const float maxWeight = 4.0f;
            float sumWag = 0.0f;
            float sumPoint = 0.0f;

            //            Punkt[] punkts = new Punkt[N]
            //            {
            //                new Punkt(0.35f,7.07f), new Punkt(0.35f,7.07f),new Punkt(0.35f,7.07f), new Punkt(0.35f,7.07f),new Punkt(0.35f,7.07f), new Punkt(0.33f,1.67f),new Punkt(0.35f,7.07f), new Punkt(0.25f,3.75f),
            //new Punkt(0.50f,2.50f), new Punkt(0.25f,3.75f),new Punkt(0.58f,11.55f), new Punkt(0.71f,14.14f),new Punkt(0.50f,5.00f), new Punkt(0.20f,2.00f),new Punkt(0.33f,5.00f), new Punkt(0.33f,10.0f),
            //new Punkt(0.25f,1.25f), new Punkt(0.33f,1.67f),new Punkt(0.29f,5.77f), new Punkt(0.29f,5.77f),new Punkt(0.41f,16.33f), new Punkt(0.41f,16.33f),new Punkt(0.71f,28.28f)

            //            };

            Punkt[] punkts = new Punkt[N]
            {
                new Punkt(0.35f,7.07f), new Punkt(0.35f,7.07f),new Punkt(0.35f,7.07f), new Punkt(0.35f,7.07f),new Punkt(0.35f,7.07f), new Punkt(0.33f,1.67f),new Punkt(0.35f,7.07f), new Punkt(0.25f,3.75f),
new Punkt(0.50f,2.50f), new Punkt(0.25f,3.75f),new Punkt(0.58f,11.55f), new Punkt(0.71f,14.14f),new Punkt(0.50f,5.00f), new Punkt(0.20f,2.00f),new Punkt(0.33f,5.00f), new Punkt(0.33f,10.0f),
new Punkt(0.25f,1.25f), new Punkt(0.33f,1.67f),new Punkt(0.29f,5.77f), new Punkt(0.29f,5.77f),new Punkt(0.41f,16.33f), new Punkt(0.41f,16.33f),new Punkt(0.71f,28.28f),new Punkt(0.25f,1.25f), new Punkt(0.33f,1.67f),new Punkt(0.29f,5.77f), new Punkt(0.29f,5.77f),new Punkt(0.41f,16.33f), new Punkt(0.41f,16.33f),new Punkt(0.71f,28.28f)
           };

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //sortowanie
            int n = punkts.Length;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (punkts[i].point < punkts[i + 1].point)
                    {
                        Punkt tmp = punkts[i];
                        punkts[i] = punkts[i + 1];
                        punkts[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);

            n = punkts.Length;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (punkts[i].waga < punkts[i + 1].waga)
                    {
                        Punkt tmp = punkts[i];
                        punkts[i] = punkts[i + 1];
                        punkts[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);

            bruteforce(punkts, maxWeight);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds);



        }

        public static void bruteforce(Punkt[] punkts, float maxWeight)
        {
            float bestValue = 0;
            int bestPosition = 0;
            int size = punkts.Length;

            var permutations = (long)Math.Pow(2, size);

            for (int i = 0; i < permutations; i++)
            {
                float total = 0;
                float weight = 0;
                for (int j = 0; j < size; j++)
                {
                    if (((i >> j) & 1) != 1)
                        continue;
                    total += punkts[j].point;
                    weight += punkts[j].waga;
                }
                if (weight <= maxWeight && total > bestValue)
                {
                    bestPosition = i;
                    bestValue = total;
                }
            }
            var include = new List<Punkt>();
            for (int j = 0; j < size; j++)
            {
                if (((bestPosition >> j) & 1) == 1)
                    include.Add(punkts[j]);
            }
    }

    public static void rucksack()
        {
            //Stopwatch stopwatch = Stopwatch.StartNew();
            //List<float> ratio = new List<float>();

            //for (int i = 0; i < punkts.Length; i++)
            //{
            //    ratio.Add(punkts[i].point / punkts[i].waga);
            //}

            //int n = ratio.Count;
            //do
            //{
            //    for (int i = 0; i < n - 1; i++)
            //    {
            //        if (ratio[i] < ratio[i + 1])
            //        {
            //            float tmp = ratio[i];
            //            ratio[i] = ratio[i + 1];
            //            ratio[i + 1] = tmp;

            //            Punkt tmp2 = punkts[i];
            //            punkts[i] = punkts[i + 1];
            //            punkts[i + 1] = tmp2;
            //        }
            //    }
            //    n--;
            //}
            //while (n > 1);


            //for (int i = 0; i < punkts.Length - 1; i++)
            //{
            //    if (sumWag + punkts[i].waga <= constSumWag)
            //    {
            //        sumPoint += punkts[i].point;
            //        sumWag += punkts[i].waga;
            //    }
            //}

            //stopwatch.Stop();


            //Console.WriteLine(sumPoint);
            //Console.WriteLine(sumWag);
            //Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds);

        }

    }
}
