using SSE2.FPU;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace SSE2.MathSSE
{
    class Float4SSE
    {
        
        Vector128<float> _vector;

        public Vector128<float> Length { get => Sse.Sqrt(Sse41.DotProduct(_vector,_vector,255)); }

        public Float4SSE Normalized { get { return new Float4SSE(Sse.Divide(_vector, Length)); } }

        public Vector128<float> Vector { get => _vector; set => _vector = value; }

        public Float4SSE()
        {

        }

        public Float4SSE(float[] str)
        {
            unsafe 
            {
                fixed (float* ptr = &str[0])
                {
                    _vector = Sse.LoadVector128(ptr);
                }
            }
        }

        public Float4SSE(Vector128<float> vector)
        {
            _vector = vector;

        }

        public Float4SSE(Float4SSE vector)
        {
            _vector = vector.Vector;

        }


        #region operator

        public static Float4SSE operator +(Float4SSE v1, Float4SSE v2)
        {
            return new Float4SSE
                (
                    Sse.Add(v1._vector, v2._vector)
                );
        }

        public static Float4SSE operator -(Float4SSE v1, Float4SSE v2)
        {
            return new Float4SSE
                (
                    Sse.Subtract(v1.Vector, v2.Vector)
                );
        }

        public static Float4SSE operator *(Float4SSE v1, Float4SSE v2)
        {
            return new Float4SSE
                (
                    Sse.Multiply(v1.Vector, v2.Vector)
                );
        }

        public static Float4SSE operator /(Float4SSE v1, Float4SSE v2)
        {
            return new Float4SSE
                (
                    Sse.Divide(v1.Vector, v2.Vector)
                );
        }


        //Skalar

        public static Float4SSE operator +(Float4SSE v, float value)
        {
            float[] arrayTemp = new float[4] { value, value, value, value };
            unsafe
            {
                fixed (float* fptr = &arrayTemp[0])
                {
                    Vector128<float> temp = Sse3.LoadVector128(fptr);
                    return new Float4SSE
                        (
                        Sse.Add(v._vector, temp)
                        );
                }
            }
        }

        public static Float4SSE operator +(float value, Float4SSE v)
        {
            float[] arrayTemp = new float[4] { value, value, value, value };
            unsafe
            {
                fixed (float* fptr = &arrayTemp[0])
                {
                    Vector128<float> temp = Sse3.LoadVector128(fptr);
                    return new Float4SSE
                        (
                        Sse.Add(v._vector, temp)
                        );
                }
            }
        }

        public static Float4SSE operator -(Float4SSE v, float value)
        {
            float[] arrayTemp = new float[4] { value, value, value, value };
            unsafe
            {
                fixed (float* fptr = &arrayTemp[0])
                {
                    Vector128<float> temp = Sse3.LoadVector128(fptr);
                    return new Float4SSE
                        (
                        Sse.Subtract(v._vector, temp)
                        );
                }
            }
        }

        public static Float4SSE operator -(Float4SSE v)
        {
            float[] arrayTemp = new float[4] { 0, 0, 0, 0 };
            unsafe
            {
                fixed (float* fptr = &arrayTemp[0])
                {
                    Vector128<float> temp = Sse3.LoadVector128(fptr);
                    return new Float4SSE
                        (
                        Sse.Subtract(temp, v._vector)
                        );
                }
            }
        }

        public static Float4SSE operator *(Float4SSE v, float value)
        {
            float[] arrayTemp = new float[4] { value, value, value, value };
            unsafe
            {
                fixed (float* fptr = &arrayTemp[0])
                {
                    Vector128<float> temp = Sse3.LoadVector128(fptr);
                    return new Float4SSE
                        (
                        Sse.Multiply(v._vector, temp)
                        );
                }
            } 
        }

        public static Float4SSE operator *(float value, Float4SSE v)
        {
            float[] arrayTemp = new float[4] { value, value, value, value };
            unsafe
            {
                fixed (float* fptr = &arrayTemp[0])
                {
                    Vector128<float> temp = Sse3.LoadVector128(fptr);
                    return new Float4SSE
                        (
                        Sse.Multiply(v._vector, temp)
                        );
                }
            }
        }

        public static Float4SSE operator /(Float4SSE v, float value)
        {
            float[] arrayTemp = new float[4] { value, value, value, value };
            unsafe
            {
                fixed (float* fptr = &arrayTemp[0])
                {
                    Vector128<float> temp = Sse3.LoadVector128(fptr);
                    return new Float4SSE
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

        public Float4SSE Cross(Float4SSE v)
        {



            return new Float4SSE
               (

               );
        }

        public Float4SSE Dot(Float4SSE v)
        {
            return new Float4SSE
                (
                    Sse41.DotProduct(_vector, v._vector, 255)
                );
        }

        public Float4SSE Saturat()
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
                    return new Float4SSE(Sse.Min(maxs, Sse.Max(mins, _vector)));
                }
            }
        }

        public Float4 getFloat()
        {

            float[] temp = new float[4];
            unsafe
            {
                fixed (float* tempptr = &temp[0])
                {
                    Sse3.Store(tempptr, _vector);
                    return new Float4(temp[0], temp[1], temp[2], temp[3]);
                }
            }
        }

    }
}
