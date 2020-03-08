namespace Snake_Moves
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string word = Console.ReadLine();

            string[,] matrix = new string[input[0], input[1]];

            int b = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (b > word.Length - 1) b = 0;
                        matrix[row, col] = word[b++].ToString();
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (b > word.Length - 1) b = 0;
                        matrix[row, col] = word[b++].ToString();
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
