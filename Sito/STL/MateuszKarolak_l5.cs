using System;
using Nito.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace STL
{
    class Program
    {
     public struct Abc
        {
            double a;

            public Abc(double a)
            {
                this.a = a;
            }
        }

        static void Main(string[] args)
        {
            const int elements = 1000000;
            Stopwatch timer = new Stopwatch();
            float t1 = 0;
            float t2 = 0;
            float t3 = 0;


            Abc abc = new Abc(23);

            List <Abc> vector = new List<Abc>();
            LinkedList<Abc> list = new LinkedList<Abc>();
            Deque<Abc> dequ = new Deque<Abc>();
            #region pushback

            for (int i =0; i< elements; i++)
            {
                timer.Start();
                vector.Add(abc);
                timer.Stop();
                t1 += (float)timer.Elapsed.TotalMilliseconds;

                timer.Reset();
            };


            for (int i = 0; i < elements; i++)
            {
                timer.Start();
                list.AddLast(abc);
                timer.Stop();
                t2 += (float)timer.Elapsed.TotalMilliseconds;

                timer.Reset();
            }



            for (int i = 0; i < elements; i++)
            {
                timer.Start();
                dequ.AddToBack(abc);
                timer.Stop();
                t3 += (float)timer.Elapsed.TotalMilliseconds;

                timer.Reset();

            }


            Console.WriteLine("Start");
            Console.WriteLine("Block push_back");
            Console.WriteLine(elements + " items");
            Console.WriteLine("Vector: " + t1);
            Console.WriteLine("List: " + t2);
            Console.WriteLine("Deque: " + t3);

            /////
            vector.Clear();
            list.Clear();
            dequ.Clear();

            t1 = 0;
            t2 = 0;
            t3 = 0;

            for (int i = 0; i < elements; i++)
            {
                timer.Start();
                vector.Add(abc);
                timer.Stop();
                t1 += (float)timer.Elapsed.TotalMilliseconds;

                timer.Reset();

                timer.Start();
                list.AddLast(abc);
                timer.Stop();
                t2 += (float)timer.Elapsed.TotalMilliseconds;

                timer.Reset();

                timer.Start();
                dequ.AddToBack(abc);
                timer.Stop();
                t3 += (float)timer.Elapsed.TotalMilliseconds;

                timer.Reset();
            }


            Console.WriteLine("interleaved push_back");
            Console.WriteLine(elements + " items");
            Console.WriteLine("Vector: " + t1);
            Console.WriteLine("List: " + t2);
            Console.WriteLine("Deque: " + t3);
            #endregion
            ////////////////////////////////////
            #region insert
            t1 = 0;
            t2 = 0;
            t3 = 0;
            float t4 = 0;
            float t5 = 0;
            float t6 = 0;
            for (int i = 0; i < 1000; i++)
            {
                Random random = new Random();
                int ran = random.Next(0, elements);

                timer.Start();
                vector.ElementAt(ran);
                timer.Stop();
                t4 += (float)timer.Elapsed.TotalMilliseconds;
                timer.Reset();

                timer.Start();
                vector.Insert(ran, abc);
                timer.Stop();
                t1 += (float)timer.Elapsed.TotalMilliseconds;
                timer.Reset();

                ////////////
                ///
                timer.Start();
                LinkedListNode<Abc> node = FindInList(list, ran);
                timer.Stop();
                t5 += (float)timer.Elapsed.TotalMilliseconds;

                timer.Start();
                list.AddAfter(node, abc);
                timer.Stop();
                t2 += (float)timer.Elapsed.TotalMilliseconds;
                timer.Reset();
                ///////////
                ///

                timer.Start();
                dequ.ElementAt(ran);
                timer.Stop();
                t6 += (float)timer.Elapsed.TotalMilliseconds;
                timer.Reset();

                timer.Start();
                dequ.Insert(ran,abc);
                timer.Stop();
                t3 += (float)timer.Elapsed.TotalMilliseconds;
                timer.Reset();
            }

            #endregion


            Console.WriteLine("interlaved insert");
            Console.WriteLine(1000 + " items");
            Console.WriteLine("Vector: " + (t1 - t4));
            Console.WriteLine("List: " + (t2 - t5));
            Console.WriteLine("Deque: " + (t3 - t6));

            Console.WriteLine("iterator movment");
            Console.WriteLine(elements + " items");
            Console.WriteLine("Vector: " + t4);
            Console.WriteLine("List: " + t5);
            Console.WriteLine("Deque: " + t6);

            #region Remove
            t1 = 0;
            t2 = 0;
            t3 = 0;
            t4 = 0;
            t5 = 0;
            t6 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Random random = new Random();
                int ran = random.Next(0, elements);

                timer.Start();
                vector.ElementAt(ran);
                timer.Stop();
                t4 += (float)timer.Elapsed.TotalMilliseconds;
                timer.Reset();

                timer.Start();
                vector.RemoveAt(ran);
                timer.Stop();
                t1 += (float)timer.Elapsed.TotalMilliseconds;
                timer.Reset();

                ////////////
                ///
                timer.Start();
                LinkedListNode<Abc> node = FindInList(list, ran);
                timer.Stop();
                t5 += (float)timer.Elapsed.TotalMilliseconds;

                timer.Start();
                list.Remove(node);
                timer.Stop();
                t2 += (float)timer.Elapsed.TotalMilliseconds;
                timer.Reset();
                ///////////
                ///

                timer.Start();
                dequ.ElementAt(ran);
                timer.Stop();
                t6 += (float)timer.Elapsed.TotalMilliseconds;
                timer.Reset();

                timer.Start();
                dequ.RemoveAt(ran);
                timer.Stop();
                t3 += (float)timer.Elapsed.TotalMilliseconds;
                timer.Reset();
            }

            #endregion


            Console.WriteLine("interlaved remove");
            Console.WriteLine(1000 + " items");
            Console.WriteLine("Vector: " + (t1 - t4));
            Console.WriteLine("List: " + (t2 - t5));
            Console.WriteLine("Deque: " + (t3 - t6));
            Console.WriteLine("Stop");

            Console.ReadKey();



        }

        public static LinkedListNode<Abc> FindInList(LinkedList<Abc> list, int index)
        {
            LinkedListNode<Abc> node = list.First;
            int i = 0;
            while (!(i == index))
            {
                i++;
                node = node.Next;
            }
            return node;
        }
    }
}


////Start
//Block push_back
//1000000 items
//Vector: 113,5433
//List: 202,1829
//Deque: 129,2189
//interleaved push_back
//1000000 items
//Vector: 106,6911
//List: 193,8829
//Deque: 110,4964
//interlaved insert
//1000 items
//Vector: 322,6676
//List: 0,7297363
//Deque: 890,4827
//iterator movment
//1000000 items
//Vector: 0,9567886
//List: 826,562
//Deque: 0,7169973
//interlaved remove
//1000 items
//Vector: 262,3245
//List: 0,3858643
//Deque: 925,4299
////Stop
