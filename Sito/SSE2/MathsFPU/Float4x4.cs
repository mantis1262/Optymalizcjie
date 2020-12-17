using System;
using System.Numerics;

namespace SSE2.FPU
{
    public class Float4x4
    {

        private Float4[] matrix;
        #region properties
        public Float4[] Matrix { get => matrix; set => matrix = value; }

        public float M11 { get => matrix[0].X; set => matrix[0].X = value; }  
        public float M12 { get => matrix[1].X; set => matrix[1].X = value; }
        public float M13 { get => matrix[2].X; set => matrix[2].X = value; }
        public float M14 { get => matrix[3].X; set => matrix[3].X = value; }

        public float M21 { get => matrix[0].Y; set => matrix[0].Y = value; }
        public float M22 { get => matrix[1].Y; set => matrix[1].Y = value; }
        public float M23 { get => matrix[2].Y; set => matrix[2].Y = value; }
        public float M24 { get => matrix[3].Y; set => matrix[3].Y = value; }

        public float M31 { get => matrix[0].Z; set => matrix[0].Z = value; }
        public float M32 { get => matrix[1].Z; set => matrix[1].Z = value; }
        public float M33 { get => matrix[2].Z; set => matrix[2].Z = value; }
        public float M34 { get => matrix[3].Z; set => matrix[3].Z = value; }

        public float M41 { get => matrix[0].W; set => matrix[0].W = value; }
        public float M42 { get => matrix[1].W; set => matrix[1].W = value; }
        public float M43 { get => matrix[2].W; set => matrix[2].W = value; }
        public float M44 { get => matrix[3].W; set => matrix[3].W = value; }

        #endregion
        public Float4x4(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44)
        {
            Matrix = new Float4[4];
            for (int i = 0; i < 4; i++)
                Matrix[i] = new Float4();

            M11 = m11;
            M12 = m12;
            M13 = m13;
            M14 = m14;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M24 = m24;
            M31 = m31;
            M32 = m32;
            M33 = m33;
            M34 = m34;
            M41 = m41;
            M42 = m42;
            M43 = m43;
            M44 = m44;
        }

        public Float4x4(Float4x4 matrix)
        {
            M11 = matrix.M11;
            M12 = matrix.M12;
            M13 = matrix.M13;
            M14 = matrix.M14;
            M21 = matrix.M21;
            M22 = matrix.M22;
            M23 = matrix.M23;
            M24 = matrix.M24;
            M31 = matrix.M31;
            M32 = matrix.M32;
            M33 = matrix.M33;
            M34 = matrix.M34;
            M41 = matrix.M41;
            M42 = matrix.M42;
            M43 = matrix.M43;
            M44 = matrix.M44;
        }

        public static Float4x4 Identity 
        {
            get => new Float4x4
                (1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);
        }

        public bool IsIdentity
        {
            get => (M11 == 1f) && (M22 == 1f) && (M33 == 1f) && (M44 == 1f);
        }

        public void SetTranslation(Float3 vector)
        {
            M14 = vector.X;
            M24 = vector.Y;
            M34 = vector.Z;
        }

        public void SetScale(Float3 vector)
        {
            M11 = vector.X;
            M22 = vector.Y;
            M33 = vector.Z;
        }

        public void SetColumn(int number, Float4 column)
        {
            switch (number)
            {
                case 0:
                    {
                        matrix[0] = column;
                        break;
                    }
                case 1:
                    {
                        matrix[1] = column;
                        break;
                    }
                case 2:
                    {
                        matrix[2] = column;
                        break;
                    }
                case 3:
                    {
                        matrix[3] = column;
                        break;
                    }
            }
        }

        public static Float4x4 operator +(Float4x4 matrix1, Float4x4 matrix2)
        {
            return new Float4x4
                (matrix1.M11 + matrix2.M11, matrix1.M12 + matrix2.M12, matrix1.M13 + matrix2.M13, matrix1.M14 + matrix2.M14,
                matrix1.M21 + matrix2.M21, matrix1.M22 + matrix2.M22, matrix1.M23 + matrix2.M23, matrix1.M24 + matrix2.M24,
                matrix1.M31 + matrix2.M31, matrix1.M32 + matrix2.M32, matrix1.M33 + matrix2.M33, matrix1.M34 + matrix2.M34,
                matrix1.M41 + matrix2.M41, matrix1.M42 + matrix2.M42, matrix1.M43 + matrix2.M43, matrix1.M44 + matrix2.M44);
        }

        public static Float4x4 operator -(Float4x4 matrix)
        {
            return new Float4x4
                (-matrix.M11, -matrix.M12, -matrix.M13, -matrix.M14,
                -matrix.M21, -matrix.M22, -matrix.M23, -matrix.M24,
                -matrix.M31, -matrix.M32, -matrix.M33, -matrix.M34,
                -matrix.M41, -matrix.M42, -matrix.M43, -matrix.M44);
        }

        public static Float4x4 operator -(Float4x4 matrix1, Float4x4 matrix2)
        {
            return new Float4x4
                (matrix1.M11 - matrix2.M11, matrix1.M12 - matrix2.M12, matrix1.M13 - matrix2.M13, matrix1.M14 - matrix2.M14,
                matrix1.M21 - matrix2.M21, matrix1.M22 - matrix2.M22, matrix1.M23 - matrix2.M23, matrix1.M24 - matrix2.M24,
                matrix1.M31 - matrix2.M31, matrix1.M32 - matrix2.M32, matrix1.M33 - matrix2.M33, matrix1.M34 - matrix2.M34,
                matrix1.M41 - matrix2.M41, matrix1.M42 - matrix2.M42, matrix1.M43 - matrix2.M43, matrix1.M44 - matrix2.M44);
        }

        public static Float4x4 operator *(Float4x4 matrix, float value)
        {
            return new Float4x4
                (matrix.M11 * value, matrix.M12 * value, matrix.M13 * value, matrix.M14 * value,
                matrix.M21 * value, matrix.M22 * value, matrix.M23 * value, matrix.M24 * value,
                matrix.M31 * value, matrix.M32 * value, matrix.M33 * value, matrix.M34 * value,
                matrix.M41 * value, matrix.M42 * value, matrix.M43 * value, matrix.M44 * value);
        }

        public static Float4 operator *(Float4x4 matrix, Float4 vector)
        {
            return new Float4
                (
                    matrix.M11 * vector.X + matrix.M12 * vector.Y + matrix.M13 * vector.Z + matrix.M14 * vector.W,
                    matrix.M21 * vector.X + matrix.M22 * vector.Y + matrix.M23 * vector.Z + matrix.M24 * vector.W,
                    matrix.M31 * vector.X + matrix.M32 * vector.Y + matrix.M33 * vector.Z + matrix.M34 * vector.W,
                    matrix.M41 * vector.X + matrix.M42 * vector.Y + matrix.M43 * vector.Z + matrix.M44 * vector.W
                );
        }

        public static Float4 operator *(Float4x4 matrix, Float3 vector)
        {
            return new Float4
                (
                    matrix.M11 * vector.X + matrix.M12 * vector.Y + matrix.M13 * vector.Z + matrix.M14 * 1f,
                    matrix.M21 * vector.X + matrix.M22 * vector.Y + matrix.M23 * vector.Z + matrix.M24 * 1f,
                    matrix.M31 * vector.X + matrix.M32 * vector.Y + matrix.M33 * vector.Z + matrix.M34 * 1f,
                    matrix.M41 * vector.X + matrix.M42 * vector.Y + matrix.M43 * vector.Z + matrix.M44 * 1f
                );
        }

        public static Float4x4 operator *(Float4x4 matrix1, Float4x4 matrix2)
        {
            return new Float4x4
                (
                    matrix1.M11 * matrix2.M11 + matrix1.M12 * matrix2.M21 + matrix1.M13 * matrix2.M31 + matrix1.M14 * matrix2.M41,
                    matrix1.M11 * matrix2.M12 + matrix1.M12 * matrix2.M22 + matrix1.M13 * matrix2.M32 + matrix1.M14 * matrix2.M42,
                    matrix1.M11 * matrix2.M13 + matrix1.M12 * matrix2.M23 + matrix1.M13 * matrix2.M33 + matrix1.M14 * matrix2.M43,
                    matrix1.M11 * matrix2.M14 + matrix1.M12 * matrix2.M24 + matrix1.M13 * matrix2.M34 + matrix1.M14 * matrix2.M44,

                    matrix1.M21 * matrix2.M11 + matrix1.M22 * matrix2.M21 + matrix1.M23 * matrix2.M31 + matrix1.M24 * matrix2.M41,
                    matrix1.M21 * matrix2.M12 + matrix1.M22 * matrix2.M22 + matrix1.M23 * matrix2.M32 + matrix1.M24 * matrix2.M42,
                    matrix1.M21 * matrix2.M13 + matrix1.M22 * matrix2.M23 + matrix1.M23 * matrix2.M33 + matrix1.M24 * matrix2.M43,
                    matrix1.M21 * matrix2.M14 + matrix1.M22 * matrix2.M24 + matrix1.M23 * matrix2.M34 + matrix1.M24 * matrix2.M44,

                    matrix1.M31 * matrix2.M11 + matrix1.M32 * matrix2.M21 + matrix1.M33 * matrix2.M31 + matrix1.M34 * matrix2.M41,
                    matrix1.M31 * matrix2.M12 + matrix1.M32 * matrix2.M22 + matrix1.M33 * matrix2.M32 + matrix1.M34 * matrix2.M42,
                    matrix1.M31 * matrix2.M13 + matrix1.M32 * matrix2.M23 + matrix1.M33 * matrix2.M33 + matrix1.M34 * matrix2.M43,
                    matrix1.M31 * matrix2.M14 + matrix1.M32 * matrix2.M24 + matrix1.M33 * matrix2.M34 + matrix1.M34 * matrix2.M44,

                    matrix1.M41 * matrix2.M11 + matrix1.M42 * matrix2.M21 + matrix1.M43 * matrix2.M31 + matrix1.M44 * matrix2.M41,
                    matrix1.M41 * matrix2.M12 + matrix1.M42 * matrix2.M22 + matrix1.M43 * matrix2.M32 + matrix1.M44 * matrix2.M42,
                    matrix1.M41 * matrix2.M13 + matrix1.M42 * matrix2.M23 + matrix1.M43 * matrix2.M33 + matrix1.M44 * matrix2.M43,
                    matrix1.M41 * matrix2.M14 + matrix1.M42 * matrix2.M24 + matrix1.M43 * matrix2.M34 + matrix1.M44 * matrix2.M44
                );
        }

        public static bool operator ==(Float4x4 matrix1, Float4x4 matrix2)
        {
            return
                (matrix1.M11 == matrix2.M11) && (matrix1.M12 == matrix2.M12) && (matrix1.M13 == matrix2.M13) && (matrix1.M14 == matrix2.M14) &&
                (matrix1.M21 == matrix2.M21) && (matrix1.M22 == matrix2.M22) && (matrix1.M23 == matrix2.M23) && (matrix1.M24 == matrix2.M24) &&
                (matrix1.M31 == matrix2.M31) && (matrix1.M32 == matrix2.M32) && (matrix1.M33 == matrix2.M33) && (matrix1.M34 == matrix2.M34) &&
                (matrix1.M41 == matrix2.M41) && (matrix1.M42 == matrix2.M42) && (matrix1.M43 == matrix2.M43) && (matrix1.M44 == matrix2.M44);
        }

        public static bool operator !=(Float4x4 matrix1, Float4x4 matrix2)
        {
            return
                (matrix1.M11 != matrix2.M11) && (matrix1.M12 != matrix2.M12) && (matrix1.M13 != matrix2.M13) && (matrix1.M14 != matrix2.M14) &&
                (matrix1.M21 != matrix2.M21) && (matrix1.M22 != matrix2.M22) && (matrix1.M23 != matrix2.M23) && (matrix1.M24 != matrix2.M24) &&
                (matrix1.M31 != matrix2.M31) && (matrix1.M32 != matrix2.M32) && (matrix1.M33 != matrix2.M33) && (matrix1.M34 != matrix2.M34) &&
                (matrix1.M41 != matrix2.M41) && (matrix1.M42 != matrix2.M42) && (matrix1.M43 != matrix2.M43) && (matrix1.M44 != matrix2.M44);
        }

        public string PrintContent()
        {
            return M11.ToString() + ", " + M12.ToString() + ", " + M13.ToString() + ", " + M14.ToString() + "\n" +
                M21.ToString() + ", " + M22.ToString() + ", " + M23.ToString() + ", " + M24.ToString() + "\n" +
                M31.ToString() + ", " + M32.ToString() + ", " + M33.ToString() + ", " + M34.ToString() + "\n" +
                M41.ToString() + ", " + M42.ToString() + ", " + M43.ToString() + ", " + M44.ToString();
        }
    }
}
