using System;

namespace ForAMomentIWasSoExcited_Code.Algorithms
{
    public static class Sorting
    {
        #region SelectionSort
        //https://www.youtube.com/watch?v=xWBP4lzkoyM
        public static T[] SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            var length = arr.Length;

            for (int i = 0; i < length; i++)
            {
                var current = arr[i];
                var min = i;
                for (int j = i + 1; j < length; j++)
                {
                    var next = arr[j];
                    if (current.CompareTo(next) > 0)
                    {
                        current = next;
                        min = j;
                    }
                    arr[j] = next;
                }
                arr[min] = arr[i];
                arr[i] = current;
            }
            return arr;
        }
        #endregion

        #region BubbleSort
        //https://www.youtube.com/watch?v=nmhjrI-aW5o
        public static T[] BubbleSort<T>(T[] arr) where T : IComparable<T>
        {
            for (int i = 0, n = arr.Length - 1; n > 0; i++, Iterator(ref n, ref i))
            {
                if (arr[i].CompareTo(arr[i + 1]) > 0)
                {
                    var current = arr[i];
                    var next = arr[i + 1];
                    arr[i] = next;
                    arr[i + 1] = current;
                }
            }
            return arr;
        }

        private static void Iterator(ref int n, ref int i)
        {
            if (i == n)
            {
                i = 0;
                n--;
            }
        } 
        #endregion
    }
}
