using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE2.FPU
{
    public class Float3
    {
         float _x;
         float _y;
         float _z;

        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public float Z { get => _z; set => _z = value; }

        public float Length { get => (float)Math.Sqrt(X * X + Y * Y + Z * Z); }

        public Float3 Normalized { get { return this / Length; } }

        public Float3()
        {
        }

        public Float3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        #region operator
        public static Float3 operator +(Float3 v1, Float3 v2)
        {
            return new Float3
                (
                    v1.X + v2.X,
                    v1.Y + v2.Y,
                    v1.Z + v2.Z
                );
        }

        public static Float3 operator +(Float3 v1, float v2)
        {
            return new Float3
                (
                    v1.X + v2,
                    v1.Y + v2,
                    v1.Z + v2
                );
        }

        public static Float3 operator -(Float3 v)
        {
            return new Float3(-v.X, -v.Y, -v.Z);
        }

        public static Float3 operator -(Float3 v1, Float3 v2)
        {
            return new Float3
                (
                    v1.X - v2.X,
                    v1.Y - v2.Y,
                    v1.Z - v2.Z
                );
        }

        public static Float3 operator -(Float3 v1, float v2)
        {
            return new Float3
                (
                    v1.X - v2,
                    v1.Y - v2,
                    v1.Z - v2
                );
        }

        public static Float3 operator *(Float3 v1, float value)
        {
            return new Float3
                (
                    v1.X * value,
                    v1.Y * value,
                    v1.Z * value
                );
        }

        public static Float3 operator *(float value, Float3 v1)
        {
            return new Float3
                (
                    v1.X * value,
                    v1.Y * value,
                    v1.Z * value
                );
        }

        public static Float3 operator *(Float3 left, Float3 right)
        {
            return new Float3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
        }

        public static Float3 operator /(Float3 v, float value)
        {
            return new Float3
                (
                    v.X / value,
                    v.Y / value,
                    v.Z / value
                );
        }

        public static Float3 operator /(Float3 v, Float3 value)
        {
            return new Float3
                (
                    v.X / value.X,
                    v.Y / value.Y,
                    v.Z / value.Z
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

        public Float3 Cross(Float3 v)
        {
            return new Float3
                (
                    Y * v.Z - Z * v.Y,
                    Z * v.X - X * v.Z,
                    X * v.Y - Y * v.X
                );
        }

        public float Dot(Float3 v)
        {
            return _x * v.X + _y * v.Y + _z * v.Z;
        }

        public Float3 Reflect(Float3 normal)
        {   
            return this - normal * (2 * Dot(normal)) ;
        }

        public override string ToString()
        {
            return "{" + X + "," + Y + "," + Z + "}";
        }

        public Float3 saturate()
        {
            Float3 result = new Float3(); 
           result.X = Math.Min(1, Math.Max(0, X));
           result.Y = Math.Min(1, Math.Max(0, Y));
           result.Z = Math.Min(1, Math.Max(0, Z));
            return result;
        }

    }
}
