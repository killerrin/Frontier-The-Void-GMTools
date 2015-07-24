using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier_The_Void_GMTools.DnDTools
{
    public struct HexCoordinate
    {
        public int X;
        public int Y;

        public HexCoordinate (int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", X, Y);
        }
    }
}
