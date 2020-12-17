using System;
using System.Collections.Generic;
using System.Text;

namespace SSE2.MathSSE
{
    class Float3SSE
    {

        float _x;
        float _y;
        float _z;

        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public float Z { get => _z; set => _z = value; }

        public float Length { get => (float)Math.Sqrt(X * X + Y * Y + Z * Z); }

        public Float3SSE Normalized { get { return this / Length; } }

        public Float3SSE()
        {
        }

        public Float3SSE(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        #region operator
        public static Float3SSE operator +(Float3SSE v1, Float3SSE v2)
        {
            return new Float3SSE
                (
                    v1.X + v2.X,
                    v1.Y + v2.Y,
                    v1.Z + v2.Z
                );
        }

        public static Float3SSE operator -(Float3SSE v)
        {
            return new Float3SSE(-v.X, -v.Y, -v.Z);
        }

        public static Float3SSE operator -(Float3SSE v1, Float3SSE v2)
        {
            return new Float3SSE
                (
                    v1.X - v2.X,
                    v1.Y - v2.Y,
                    v1.Z - v2.Z
                );
        }

        public static Float3SSE operator *(Float3SSE v1, float value)
        {
            return new Float3SSE
                (
                    v1.X * value,
                    v1.Y * value,
                    v1.Z * value
                );
        }

        public static Float3SSE operator *(float value, Float3SSE v1)
        {
            return new Float3SSE
                (
                    v1.X * value,
                    v1.Y * value,
                    v1.Z * value
                );
        }

        public static Float3SSE operator *(Float3SSE left, Float3SSE right)
        {
            return new Float3SSE(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
        }

        public static Float3SSE operator /(Float3SSE v, float value)
        {
            return new Float3SSE
                (
                    v.X / value,
                    v.Y / value,
                    v.Z / value
                );
        }
        #endregion
        public void Normalize()
        {
            float length = Length;
            X = X / length;
            Y = Y / length;
            Z = Z / length;
        }

        public Float3SSE Cross(Float3SSE v)
        {
            return new Float3SSE
                (
                    Y * v.Z - Z * v.Y,
                    Z * v.X - X * v.Z,
                    X * v.Y - Y * v.X
                );
        }

        public float Dot(Float3SSE v)
        {
            return _x * v.X + _y * v.Y + _z * v.Z;
        }

        public Float3SSE Reflect(Float3SSE normal)
        {
            return this - normal * (2 * Dot(normal));
        }

    }
}
