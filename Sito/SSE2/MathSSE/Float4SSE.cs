using SSE2.FPU;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace SSE2.MathSSE
{

    public struct prop{

    private float _x;
    private float _y;
    private float _z;
    private float _w;

        public prop(float x, float y, float z, float w)
        {
            _x = x;
            _y = y;
            _z = z;
            _w = w;
        }

        public float X { get => _x; set => _x = value; }
    public float Y { get => _y; set => _y = value; }
    public float Z { get => _z; set => _z = value; }
    public float W { get => _w; set => _w = value; }

}
    class Float4SSE
    {

  

        Vector128<prop> _vector;
       

    //    public float Length { get => (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W); }

        public Float4SSE Normalized { get { return this / Length; } }

        public Vector128<float> Vector { get => _vector; set => _vector = value; }

        public Float4SSE()
        {

        }

        public Float4SSE(prop str)
        {
            unsafe 
            { 
                fixed (prop* ptr = &str)
                {

                }

            }

            Vector = Sse.LoadVector128(str);

        }

        public Float4SSE(Float3SSE v, float w)
        {
            _x = v.X;
            _y = v.Y;
            _z = v.Z;
            _w = w;
        }

        #region operator

        public static Float4SSE operator +(Float4SSE v1, Float4SSE v2)
        {
            return new Float4
                (
                    v1.X + v2.X,
                    v1.Y + v2.Y,
                    v1.Z + v2.Z,
                    v1.W + v2.W
                );
        }

        public static Float4SSE operator -(Float4SSE v)
        {
            return new Float4(-v.X, -v.Y, -v.Z, -v.W);
        }

        public static Float4SSE operator -(Float4SSE v1, Float4SSE v2)
        {
            return new Float4
                (
                    v1.X - v2.X,
                    v1.Y - v2.Y,
                    v1.Z - v2.Z,
                    v1.W - v2.W
                );
        }

        public static Float4SSE operator *(Float4SSE v, float value)
        {
            return new Float4
                (
                    v.X * value,
                    v.Y * value,
                    v.Z * value,
                    v.W * value
                );
        }

        public static Float4SSE operator /(Float4SSE v, float value)
        {
            return new Float4
                (
                    v.X / value,
                    v.Y / value,
                    v.Z / value,
                    v.W / value
                );
        }

        public static bool operator ==(Float4SSE left, Float4SSE right)
        {
            return (left.X == right.X && left.Y == right.Y && left.Z == right.Z && left.W == right.W);
        }

        public static bool operator !=(Float4SSE left, Float4SSE right)
        {
            return (left.X != right.X || left.Y != right.Y || left.Z != right.Z || left.W != right.W);
        }

        #endregion

        public void Normalize()
        {
            float length = Length;
            X = X / length;
            Y = Y / length;
            Z = Z / length;
            W = W / length;
        }

    }
}
