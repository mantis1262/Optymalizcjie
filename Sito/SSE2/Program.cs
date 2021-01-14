using System;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;
using System.Diagnostics;
using System.Collections.Generic;
using SSE2.FPU;
using SSE2.MathSSE;

namespace SSE2
{
    class Program
    {

            
        static void Main(string[] args)
        {
            Float3 f3 = new Float3(10, 20, 30);
            Float3 f32 = new Float3(20, 20, 30);
            Float3SSE f3sse = new Float3SSE(new float[3] {10, 20, 30});
            Float3SSE f3sse2 = new Float3SSE(new float[3] {20, 20, 30});
            Float4 float4 = new Float4(2, 2, 2, 2);
            Float4 float42 = new Float4(-1, -31.32f, -12.3f, 2);
            Float4x4 float4X4 = new Float4x4(1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6);
            Float4SSE float4sse = new Float4SSE(new float[] { 2, 2, 2, 2 });
            Float4SSE float42sse = new Float4SSE(new float[] { -1, -31.32f, -12.3f, 2 });
            Float4x4SSE float4X4sse = new Float4x4SSE(1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6);

            Stopwatch stopwatch = new Stopwatch();
            //Float3
            Console.WriteLine("Float3");
            stopwatch.Start();
            Float3 a = f3 + f32;
            stopwatch.Stop();
            Console.WriteLine("sumaFPU" + a.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            Float3SSE asse = f3sse + f3sse2;
            stopwatch.Stop();
            Console.WriteLine("sumaSSE" + asse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();
            ///
            stopwatch.Start();
            a = f3 - f32;
            stopwatch.Stop();
            Console.WriteLine("rożnicaFPU" + a.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            asse = f3sse - f3sse2;
            stopwatch.Stop();
            Console.WriteLine("rożnicaSSE" + asse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();
            ///
            stopwatch.Start();
            a = f3 * f32;
            stopwatch.Stop();
            Console.WriteLine("ilocztnFPU" + a.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            asse = f3sse * f3sse2;
            stopwatch.Stop();
            Console.WriteLine("iloczynSSE" + asse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();
            ///
            stopwatch.Start();
            a = f3 / f32;
            stopwatch.Stop();
            Console.WriteLine("iloraz FPU" + a.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            asse = f3sse / f3sse2;
            stopwatch.Stop();
            Console.WriteLine("iloraz SSE" + asse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();

            /////
            ///
            Console.WriteLine("\n\n Skalar");
            stopwatch.Start();
            a = f3 + 1;
            stopwatch.Stop();
            Console.WriteLine("suma FPU" + a.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            asse = f3sse + 1;
            stopwatch.Stop();
            Console.WriteLine("suma SSE" + asse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();

            ///
            stopwatch.Start();
            a = f3 - 1;
            stopwatch.Stop();
            Console.WriteLine("Rożnica FPU" + a.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            asse = f3sse - 1;
            stopwatch.Stop();
            Console.WriteLine("Ronica SSE" + asse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();

            ///
            stopwatch.Start();
            a = f3 * 2;
            stopwatch.Stop();
            Console.WriteLine("iloczyn FPU" + a.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            asse = f3sse * 2;
            stopwatch.Stop();
            Console.WriteLine("iloczyn SSE" + asse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();
            ///
            stopwatch.Start();
            a = f3 / 2.5f;
            stopwatch.Stop();
            Console.WriteLine("iloraz FPU" + a.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            asse = f3sse / 2.5f;
            stopwatch.Stop();
            Console.WriteLine("iloraz SSE" + asse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();


            ///
            stopwatch.Start();
            a = f3.Normalized;
            stopwatch.Stop();
            Console.WriteLine("Normalizacjia FPU" + a.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            asse = f3sse.Normalized;
            stopwatch.Stop();
            Console.WriteLine("Normalizacjia  SSE" + asse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();

            ///
            stopwatch.Start();
            a = f3.Reflect(f32);
            stopwatch.Stop();
            Console.WriteLine("Reflect FPU" + a.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            asse = f3sse.Reflect(f3sse2);
            stopwatch.Stop();
            Console.WriteLine("Reflect SSE" + asse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();

            ///
            stopwatch.Start();
            a = f3.saturate();
            stopwatch.Stop();
            Console.WriteLine("Saturate FPU" + a.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            asse = f3sse.Saturat();
            stopwatch.Stop();
            Console.WriteLine("Saturate SSE" + asse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();

            ///
            stopwatch.Start();
           float s = f3.Dot(f32);
            stopwatch.Stop();
            Console.WriteLine("dot FPU" + s.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            asse = f3sse.Dot(f3sse2);
            stopwatch.Stop();
            Console.WriteLine("dot SSE" + asse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();

            ////
            ///Float4

            Console.WriteLine("Float3");
            stopwatch.Start();
            Float4 a4 = float4 + float42 ;
            stopwatch.Stop();
            Console.WriteLine("sumaFPU" + a4.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            Float4SSE a4sse = float42sse + float4sse;
            stopwatch.Stop();
            Console.WriteLine("sumaSSE" + a4sse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();
            ///
            stopwatch.Start();
            a4 = float4 - float42;
            stopwatch.Stop();
            Console.WriteLine("rożnicaFPU" + a4.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            a4sse = float4sse - float42sse;
            stopwatch.Stop();
            Console.WriteLine("rożnicaSSE" + a4sse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();
            ///
            stopwatch.Start();
            a4 = float4 * float42;
            stopwatch.Stop();
            Console.WriteLine("ilocztnFPU" + a4.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            a4sse = float4sse * float42sse;
            stopwatch.Stop();
            Console.WriteLine("iloczynSSE" + a4sse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();
            ///
            stopwatch.Start();
            a4 = float4 / float42;
            stopwatch.Stop();
            Console.WriteLine("iloraz FPU" + a4.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            a4sse = float4sse / float42sse;
            stopwatch.Stop();
            Console.WriteLine("iloraz SSE" + a4sse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();

            /////
            ///
            Console.WriteLine("\n\n Skalar");
            stopwatch.Start();
            a4 = float4 + 1;
            stopwatch.Stop();
            Console.WriteLine("suma FPU" + a4.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            a4sse = float4sse + 1;
            stopwatch.Stop();
            Console.WriteLine("suma SSE" + a4sse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();

            ///
            stopwatch.Start();
            a4 = float4 - 1;
            stopwatch.Stop();
            Console.WriteLine("Rożnica FPU" + a4.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            a4sse = float4sse - 1;
            stopwatch.Stop();
            Console.WriteLine("Ronica SSE" + a4sse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();

            ///
            stopwatch.Start();
            a4 = float4 * 2;
            stopwatch.Stop();
            Console.WriteLine("iloczyn FPU" + a4.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            a4sse = float4sse * 2;
            stopwatch.Stop();
            Console.WriteLine("iloczyn SSE" + a4sse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();
            ///
            stopwatch.Start();
            a4 = float4 / 2.5f;
            stopwatch.Stop();
            Console.WriteLine("iloraz FPU" + a4.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            a4sse = float4sse / 2.5f;
            stopwatch.Stop();
            Console.WriteLine("iloraz SSE" + a4sse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();

            /// 
            ///

            Console.WriteLine("macierz");

            stopwatch.Start();
           Float4 aas = float4X4 * float4;
            stopwatch.Stop();
            Console.WriteLine("dot FPU" + aas.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            float4sse = float4X4sse * float4sse;
            stopwatch.Stop();
            Console.WriteLine("dot SSE" + float4sse.Vector.ToString());
            Console.WriteLine("time" + stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();

            Console.ReadKey();


        }
    }
}
