﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SSE2.MathSSE
{
    class Int3SSE
    {

        int _a;
        int _b;
        int _c;

        public Int3SSE(int v1, int v2, int v3)
        {
            _a = v1;
            _b = v2;
            _c = v3;
        }

        public int A { get => _a; set => _a = value; }
        public int B { get => _b; set => _b = value; }
        public int C { get => _c; set => _c = value; }

    }
}
