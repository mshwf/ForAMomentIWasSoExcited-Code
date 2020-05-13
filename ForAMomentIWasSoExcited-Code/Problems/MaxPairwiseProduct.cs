using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAMomentIWasSoExcited_Code.Problems
{
    public class MaxPairwiseProduct
    {
        private static long[] ReadNumbers()
        {
            var n_str = Console.ReadLine();
            var numbers = Console.ReadLine();
            try
            {
                var my_n = int.Parse(n_str);
                var arr = numbers.Split(' ').Select(n => long.Parse(n)).ToArray();
                return arr;
            }
            catch
            {
                throw new Exception("Input should be numbers separated with spaces");
            }
        }

        public static void Execute()
        {

            long[] inputArray = ReadNumbers();
            var product = GetMaxPairwiseProduct(inputArray);
            Console.WriteLine(product);
        }


        static long GetMaxPairwiseProduct(long[] A)
        {
            long num1 = 0, num2 = 0;

            for (int i = 0; i < A.Length; i++)
            {
                long current = A[i];

                if (current > num1)
                {
                    num2 = num1;
                    num1 = current;
                }
                else if (current > num2)
                    num2 = current;
            }
            return num1 * num2;
        }
    }
}
