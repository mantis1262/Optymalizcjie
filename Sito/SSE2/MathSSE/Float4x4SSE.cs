using System;
using System.Collections.Generic;
using System.Text;

namespace SSE2.MathSSE
{
    class Float4x4SSE
    {

        private Float4SSE[] matrix;
        #region properties
        public Float4SSE[] Matrix { get => matrix; set => matrix = value; }

        #endregion
        public Float4x4SSE(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44)
        {
            Matrix = new Float4SSE[4];
            Matrix[0] = new Float4SSE(new float[] { m11, m12, m13, m14 });
            Matrix[1] = new Float4SSE(new float[] { m21, m22, m23, m24 });
            Matrix[2] = new Float4SSE(new float[] { m31, m32, m33, m34 });
            Matrix[3] = new Float4SSE(new float[] { m41, m42, m43, m44 });


        }

        public Float4x4SSE(Float4x4SSE matrix)
        {
            
        }

        public static Float4x4SSE Identity
        {
            get => new Float4x4SSE
                (
               1, 0, 0, 0,
               0, 1, 0, 0,
               0, 0, 1, 0,
               0, 0, 0, 1
                );
        }


        public static Float4SSE operator *(Float4x4SSE matrix, Float4SSE vector)
        {
            return new Float4SSE
                (
                new float[]
                {
                matrix.matrix[0].Dot(vector).getFloat().X,
                matrix.matrix[1].Dot(vector).getFloat().X,
                matrix.matrix[2].Dot(vector).getFloat().X,
                matrix.matrix[3].Dot(vector).getFloat().X
                }

                ) ;
        }
    }
}
