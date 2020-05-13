using System;
using System.Diagnostics;

namespace ForAMomentIWasSoExcited_Code.DataStructures
{
    [DebuggerDisplay("[{R}, {C}]")]
    class Point
    {
        public readonly int R;
        public readonly int C;
        public Point(int r, int c)
        {
            R = r;
            C = c;
        }
        public static Point operator +(Point a, Point b)
        => new Point(a.R + b.R, a.C + b.C);

        public static bool operator ==(Point a, Point b)
         => a.R == b.R && a.C == b.C;
        public static bool operator !=(Point a, Point b)
        => a.R != b.R || a.C != b.C;

        public override bool Equals(object obj)
        => this == (Point)obj;

        public bool IsParentTo(Point point)
        {
            if (R == point.R || C == point.C)
            {
                if (Math.Abs(R - point.R) == 1 || Math.Abs(C - point.C) == 1)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
