using System.Diagnostics;

namespace ForAMomentIWasSoExcited_Code.IJustDiscoverdThis
{
    class Loops
    {
        //loop through 2D array, row by row
        public static void LoopThrough2DArray(char[,] locs)
        {
            var rowsLength = locs.GetLength(0);
            var colsLength = locs.GetLength(1);
            for (int row = 0, col = 0; row < rowsLength && col < colsLength; Iterator(ref row, rowsLength, ref col, colsLength))
            {
                Debug.WriteLine($"[{row}, {col}]");
                Debug.WriteLine("------");
            }
        }

        private static void Iterator(ref int row, int rowsLength, ref int col, int colsLength)
        {
            if (row < rowsLength) col++;
            if (col == colsLength)
            {
                col = 0;
                row++;
            }
        }
    }
}
