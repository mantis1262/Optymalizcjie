using System;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;
using System.Diagnostics;
using System.Collections.Generic;

namespace SSE2
{
    class Program
    {
        struct float4
        {
            float x, y, z, w;
        }
            
        static void Main(string[] args)
        {

            const int DATASIZE = 1048576;
            const int TEST = 64;
            float[] time = new float[4];

            Console.WriteLine("Test retry: " + TEST);
            Console.WriteLine("____________________");


            float[] f = new float [DATASIZE];
            float[] g = new float [DATASIZE];

            for(int i = 0; i<DATASIZE; i++)
            {
                Random random = new Random();
                f[i] = (float)(random.NextDouble() * 2 - 1);
                g[i] = (float)(random.NextDouble() * 2 - 1);
            }

            float[] suma = new float[4] { 0, 0, 0, 0};

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //FPU
            for (int t = 0; t < TEST; t++)
            {
                suma[0] = 0;
                for (int i = 0; i < DATASIZE; i++)
                {
                    suma[0] += f[i] * g[i];
                }
            }
            stopwatch.Stop();
            Console.WriteLine("FPU loop time " + stopwatch.Elapsed.TotalMilliseconds);
            time[0] = (float)stopwatch.Elapsed.TotalMilliseconds;

            stopwatch.Restart();

            //FPUx4
            for (int t = 0; t < TEST; t++)
            {
                suma[1] = 0;
                for (int i = 0; i < DATASIZE / 4 * 4; i += 4)
                {
                    suma[1] += f[i] * g[i];
                    suma[1] += f[i + 1] * g[i + 1];
                    suma[1] += f[i + 2] * g[i + 2];
                    suma[1] += f[i + 3] * g[i + 3];
                }
            }
            stopwatch.Stop();
            Console.WriteLine("FPU 4xloop time " + stopwatch.Elapsed.TotalMilliseconds);
            time[1] = (float)stopwatch.Elapsed.TotalMilliseconds;

            stopwatch.Restart();

            //SSE
            for (int t = 0; t < TEST; t++)
            {
                suma[2] = 0;
                unsafe
                {
                    fixed (float* ptr_s3 = &suma[2])
                    fixed (float* ptr_f = &f[0])
                    fixed (float* ptr_g = &g[0])
                    {
                        Vector128<float> suma3 = Sse.LoadVector128(ptr_s3);
                        for (int i = 0; i < DATASIZE; i += 4)
                        {
                            
                            {
                                Vector128<float> vector = Sse.LoadVector128(ptr_f+i);
                                Vector128<float> vector2 = Sse.LoadVector128(ptr_g+i);

                                suma3 = Sse.Add(suma3, Sse41.DotProduct(vector, vector2, 255));
                            }
                        }
                        Sse.Store(ptr_s3, suma3);
                    }
                }
            }

            stopwatch.Stop();
            Console.WriteLine("SSE loop time " + stopwatch.Elapsed.TotalMilliseconds);
            time[2] = (float)stopwatch.Elapsed.TotalMilliseconds;

            stopwatch.Restart();
            for (int t = 0; t < TEST; t++)
            {
                suma[3] = 0;
                ///SSEx4
                unsafe
                {
                    fixed (float* ptr_s4 = &suma[3])
                    fixed (float* ptr_f = &f[0])
                    fixed (float* ptr_g = &g[0])
                    {
                        Vector128<float> suma4 = Sse.LoadVector128(ptr_s4);
                        for (int i = 0; i < DATASIZE / 4 * 4; i += 16)
                        {
                            
                            {
                                Vector128<float> vector = Sse.LoadVector128(ptr_f + i);
                                Vector128<float> vector2 = Sse.LoadVector128(ptr_g + i);
                                suma4 = Sse.Add(suma4, Sse41.DotProduct(vector, vector2, 255));


                                vector = Sse.LoadVector128(ptr_f + i + 4);
                                vector2 = Sse.LoadVector128(ptr_g + i + 4);
                                suma4 = Sse.Add(suma4, Sse41.DotProduct(vector, vector2, 255));


                                vector = Sse.LoadVector128(ptr_f + i + 8);
                                vector2 = Sse.LoadVector128(ptr_g + i + 8);
                                suma4 = Sse.Add(suma4, Sse41.DotProduct(vector, vector2, 255));


                                vector = Sse.LoadVector128(ptr_f + i + 12);
                                vector2 = Sse.LoadVector128(ptr_g + i + 12);
                                suma4 = Sse.Add(suma4, Sse41.DotProduct(vector, vector2, 255));

                            }
                        }
                        Sse.Store(ptr_s4, suma4);
                    }
                }
            }


            stopwatch.Stop();
            Console.WriteLine("SSE 4xloop time " + stopwatch.Elapsed.TotalMilliseconds);
            time[3] = (float)stopwatch.Elapsed.TotalMilliseconds;

            Console.WriteLine("\nFPU loop " + 1);
            Console.WriteLine("FPU 4xloop " + time[1]/time[0]);
            Console.WriteLine("SSE loop " + time[2] / time[0]);
            Console.WriteLine("SSE 4xloop " + time[3] / time[0]);



            Console.WriteLine("\nFPU loop result " + suma[0]);
            Console.WriteLine("FPU 4xloop result " + suma[1]);
            Console.WriteLine("SSE loop result " + suma[2]);
            Console.WriteLine("SSE 4xloop result " + suma[3]);

            Console.ReadKey();

        }
    }
}
