namespace Diagonal_Difference
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                int[] currArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int b = 0; b < currArr.Length; b++)
                {
                    matrix[i, b] = currArr[b];
                }
            }

            int sumLeftDi = 0;
            int currRow = 0;
            int currCol = 0;

            for (int i = 0; i < n; i++)
            {
                sumLeftDi += matrix[currRow, currCol];
                currCol++;
                currRow++;
            }

            int sumRightDi = 0;
            currRow = 0;
            currCol = n - 1;

            for (int i = 0; i < n; i++)
            {
                sumRightDi += matrix[currRow, currCol];
                currRow++;
                currCol--;
            }

            Console.WriteLine(Math.Abs(sumLeftDi - sumRightDi));
        }
    }
}
