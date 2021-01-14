using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE2.FPU
{
    public class Float4
    {
        private float _x;
        private float _y;
        private float _z;
        private float _w;

        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public float Z { get => _z; set => _z = value; }
        public float W { get => _w; set => _w = value; }
        public float Length { get => (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W); }

        public Float4 Normalized { get { return this / Length; } }

        public Float4()
        {

        }

        public Float4(float x, float y, float z, float w)
        {
            _x = x;
            _y = y;
            _z = z;
            _w = w;
        }

        public Float4(Float3 v, float w)
        {
            _x = v.X;
            _y = v.Y;
            _z = v.Z;
            _w = w;
        }

        #region operator

        public static Float4 operator +(Float4 v1, Float4 v2)
        {
            return new Float4
                (
                    v1.X + v2.X,
                    v1.Y + v2.Y,
                    v1.Z + v2.Z,
                    v1.W + v2.W
                );
        }

        public static Float4 operator +(Float4 v1, float v2)
        {
            return new Float4
                (
                    v1.X + v2,
                    v1.Y + v2,
                    v1.Z + v2,
                    v1.W + v2
                );
        }

        public static Float4 operator -(Float4 v)
        {
            return new Float4(-v.X, -v.Y, -v.Z, -v.W);
        }

        public static Float4 operator -(Float4 v1, Float4 v2)
        {
            return new Float4
                (
                    v1.X - v2.X,
                    v1.Y - v2.Y,
                    v1.Z - v2.Z,
                    v1.W - v2.W
                );
        }

        public static Float4 operator -(Float4 v1, float v2)
        {
            return new Float4
                (
                    v1.X - v2,
                    v1.Y - v2,
                    v1.Z - v2,
                    v1.W - v2
                );
        }

        public static Float4 operator *(Float4 v, float value)
        {
            return new Float4
                (
                    v.X * value,
                    v.Y * value,
                    v.Z * value,
                    v.W * value
                );
        }

        public static Float4 operator *(Float4 v, Float4 value)
        {
            return new Float4
                (
                    v.X * value.X,
                    v.Y * value.Y,
                    v.Z * value.Z,
                    v.W * value.W
                );
        }

        public static Float4 operator /(Float4 v, float value)
        {
            return new Float4
                (
                    v.X / value,
                    v.Y / value,
                    v.Z / value,
                    v.W / value
                );
        }

        public static Float4 operator /(Float4 v, Float4 value)
        {
            return new Float4
                (
                    v.X / value.X,
                    v.Y / value.Y,
                    v.Z / value.Z,
                    v.W / value.W
                );
        }

        public static bool operator ==(Float4 left, Float4 right)
        {
            return (left.X == right.X && left.Y == right.Y && left.Z == right.Z && left.W == right.W);
        }

        public static bool operator !=(Float4 left, Float4 right)
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

        public override string ToString()
        {
            return "{" + X + "," + Y + "," + Z +"," + W + "}";
        }
    }
}
