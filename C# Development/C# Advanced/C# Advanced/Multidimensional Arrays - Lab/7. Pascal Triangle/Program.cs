namespace _7._Pascal_Triangle
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            double[][] matrix = new double[n + 1][];

            for (int row = 0; row < n + 1; row++)
            {
                matrix[row] = new double[n + 1];
            }

            matrix[0][0] = 1;

            for (int row = 1; row <= n; row++)
            {
                for (int col = 1; col <= n; col++)
                {
                    matrix[row][col] += matrix[row - 1][col - 1] + matrix[row - 1][col];
                }
            }

            matrix[0][0] = 0;

            PrintMatrix(matrix);
        }

        public static void PrintMatrix(double[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(' ', matrix[row].Where(r => r != 0)));
            }
        }
    }
}