namespace _2._Sum_Matrix_Columns
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(", ");

            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);

            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }

            for (int col = 0; col < cols; col++)
            {
                int currentColSum = 0;

                for (int row = 0; row < rows; row++)
                {
                    currentColSum += matrix[row][col];

                }

                Console.WriteLine(currentColSum);
            }
        }
    }
}