using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N19_21
{
    internal readonly record struct Point(int X, int Y)
    {
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
