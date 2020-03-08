namespace Maximal_Sum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[input[0], input[1]];

            int sumResult = 0;

            int maxSum = int.MinValue;

            int[,] resultMatrix = new int[3, 3];

            for (int row = 0; row < input[0]; row++)
            {
                int[] currInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < input[1]; col++)
                {
                    matrix[row, col] = currInput[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currSum = matrix[row, col] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1] + matrix[row + 2, col] + matrix[row + 2, col + 1]
                        + matrix[row + 2, col + 2] + matrix[row + 1, col + 2] + matrix[row, col + 2];

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;

                        resultMatrix = new int[,] {
                        { matrix[row, col] , matrix[row, col + 1] , matrix[row, col + 2] } ,
                        { matrix[row + 1, col] , matrix[row + 1, col + 1] , matrix[row + 1, col + 2] },
                        { matrix[row + 2, col] , matrix[row + 2, col + 1] , matrix[row + 2, col + 2] }
                        };
                    }
                }
            }

            sumResult = maxSum;

            Console.WriteLine($"Sum = {sumResult}");

            for (int row = 0; row < resultMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < resultMatrix.GetLength(1); col++)
                {
                    Console.Write(resultMatrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
