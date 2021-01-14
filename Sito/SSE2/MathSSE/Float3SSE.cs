using SSE2.FPU;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace SSE2.MathSSE
{
    class Float3SSE
    {

        Vector128<float> _vector;
        Vector128<float> _lenght;

        public Vector128<float> Vector { get => _vector; set => _vector = value; }


        public Vector128<float> Length { get => Sse.Sqrt(Sse41.DotProduct(_vector, _vector, 255)); }
        public Float3SSE Normalized { get { return new Float3SSE(Sse.Divide(_vector, Length)); } }

        public Float3SSE()
        {
        }

        public Float3SSE(float[] str)
        {
            unsafe
            {
                fixed (float* ptr = &str[0])
                {
                    _vector = Sse.LoadVector128(ptr);
                }
            }
        }

        public Float3SSE(Vector128<float> vector)
        {
            _vector = vector;

        }

        #region operator
        //Vector
        public static Float3SSE operator +(Float3SSE v1, Float3SSE v2)
        {
            return new Float3SSE
                (
                    Sse.Add(v1._vector, v2._vector)
                );
        }

        public static Float3SSE operator -(Float3SSE v1, Float3SSE v2)
        {
            return new Float3SSE
                (
                    Sse.Subtract(v1.Vector, v2.Vector)
                );
        }


        public static Float3SSE operator *(Float3SSE v1, Float3SSE v2)
        {
            return new Float3SSE
                (
                    Sse.Multiply(v1.Vector, v2.Vector)
                );
        }

        public static Float3SSE operator /(Float3SSE v1, Float3SSE v2)
        {
            return new Float3SSE
                (
                    Sse.Divide(v1.Vector, v2.Vector)
                );
        }
    
        //Skalar
        public static Float3SSE operator +(Float3SSE v, float value)
        {
            float[] arrayTemp = new float[4] { value, value, value, 0 };
            unsafe
            {
                fixed (float* fptr = &arrayTemp[0])
                {
                    Vector128<float> temp = Sse3.LoadVector128(fptr);
                    return new Float3SSE
                        (
                        Sse.Add(v._vector, temp)
                        );
                }
            }
        }

        public static Float3SSE operator +(float value, Float3SSE v)
        {
            float[] arrayTemp = new float[4] { value, value, value, 0 };
            unsafe
            {
                fixed (float* fptr = &arrayTemp[0])
                {
                    Vector128<float> temp = Sse3.LoadVector128(fptr);
                    return new Float3SSE
                        (
                        Sse.Add(v._vector, temp)
                        );
                }
            }
        }


        public static Float3SSE operator -(Float3SSE v)
        {
            float[] arrayTemp = new float[4] { 0, 0, 0, 0 };
            unsafe
            {
                fixed (float* fptr = &arrayTemp[0])
                {
                    Vector128<float> temp = Sse3.LoadVector128(fptr);
                    return new Float3SSE
                        (
                        Sse.Subtract(temp, v._vector)
                        ) ;
                }
            }
        }

        public static Float3SSE operator -(Float3SSE v, float value)
        {
            float[] arrayTemp = new float[4] { value, value, value, 0 };
            unsafe
            {
                fixed (float* fptr = &arrayTemp[0])
                {
                    Vector128<float> temp = Sse3.LoadVector128(fptr);
                    return new Float3SSE
                        (
                        Sse.Subtract(v._vector, temp)
                        );
                }
            }
        }

        public static Float3SSE operator *(Float3SSE v, float value)
        {
            float[] arrayTemp = new float[4] { value, value, value, 0 };
            unsafe
            {
                fixed (float* fptr = &arrayTemp[0])
                {
                    Vector128<float> temp = Sse3.LoadVector128(fptr);
                    return new Float3SSE
                        (
                        Sse.Multiply(v._vector, temp)
                        );
                }
            }
        }

        public static Float3SSE operator *(float value, Float3SSE v)
        {
            float[] arrayTemp = new float[4] { value, value, value, 0 };
            unsafe
            {
                fixed (float* fptr = &arrayTemp[0])
                {
                    Vector128<float> temp = Sse3.LoadVector128(fptr);
                    return new Float3SSE
                        (
                        Sse.Multiply(v._vector, temp)
                        );
                }
            }
        }

        public static Float3SSE operator /(Float3SSE v, float value)
        {
            float[] arrayTemp = new float[4] { value, value, value, 0 };
            unsafe
            {
                fixed (float* fptr = &arrayTemp[0])
                {
                    Vector128<float> temp = Sse3.LoadVector128(fptr);
                    return new Float3SSE
                        (
                        Sse.Divide(v._vector, temp)
                        );
                }
            }
        }
        #endregion
        public void Normalize()
        {
            _vector = Sse.Divide(_vector, Length);
        }

        public Float3SSE Cross(Float3SSE v)
        {



            return new Float3SSE
               (
                   
               );
        }

        public Float3SSE Dot(Float3SSE v)
        {
            return new Float3SSE
                (
                    Sse41.DotProduct(_vector, v._vector, 255)
                );
        }

        public Float3SSE Reflect(Float3SSE normal)
        {
           return new Float3SSE(Sse.Subtract(_vector, Sse.Multiply(normal.Vector, (2f * Dot(normal)).Vector)));

        }

        public Float3SSE Saturat()
        {
            float[] max = new float[4] { 1, 1, 1, 1 };
            float[] min = new float[4] { 0, 0, 0, 0 };
            unsafe
            {
                fixed (float* maxptr = &max[0])
                fixed (float* minptr = &min[0])
                {
                    Vector128<float> mins = Sse3.LoadVector128(maxptr);
                    Vector128<float> maxs = Sse3.LoadVector128(maxptr);
                    return new Float3SSE(Sse.Min(maxs,Sse.Max(mins, _vector)));
                }
            }
        }

        public Float3 getFloat()
        {

            float[] temp = new float[4];
            unsafe
            {
                fixed (float* tempptr = &temp[0])
                {
                    Sse3.Store(tempptr, _vector);
                    return new Float3(temp[0], temp[1], temp[2]);
                }
            }
        }

    }
}
