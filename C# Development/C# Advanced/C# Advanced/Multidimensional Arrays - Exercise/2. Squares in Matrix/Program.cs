namespace _2._2x2_Squares_in_Matrix
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            //rows cols
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string[,] matrix = new string[input[0], input[1]];

            int countSquares = 0;

            for (int row = 0; row < input[0]; row++)
            {
                string[] currInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < input[1]; col++)
                {
                    matrix[row, col] = currInput[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    bool isItsSquare = matrix[row, col] == matrix[row + 1, col] && matrix[row + 1, col]
                        == matrix[row, col + 1]&& matrix[row + 1, col + 1] == matrix[row, col + 1];

                    if (isItsSquare)
                    {
                        countSquares++;
                    }
                }
            }

            Console.WriteLine(countSquares);
        }
    }
}
