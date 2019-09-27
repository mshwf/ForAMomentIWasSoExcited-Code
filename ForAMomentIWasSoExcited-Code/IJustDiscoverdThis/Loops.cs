using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ForAMomentIWasSoExcited_Code.IJustDiscoverdThis
{
    class Loops
    {
        public static void LoopThrough2DArray(char[,] locs)
        {
            var rowMax = locs.GetLength(0);
            var colMax = locs.GetLength(1);
            for (int row = 0, col = 0; row < rowMax && col < colMax; Iterator(ref row, rowMax, ref col, colMax))
            {
                Debug.WriteLine($"[{row}, {col}]");
                Debug.WriteLine("------");
            }
        }

        private static void Iterator(ref int row, int rowMax, ref int col, int colMax)
        {
            if (row < rowMax) col++;
            if (col == colMax)
            {
                col = 0;
                row++;
            }
        }
    }
}
