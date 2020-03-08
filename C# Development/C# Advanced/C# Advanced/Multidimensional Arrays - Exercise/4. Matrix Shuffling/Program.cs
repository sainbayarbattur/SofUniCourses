namespace Matrix_shuffling
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            string[][] matrix = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new string[cols];

                matrix[row] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            while (true)
            {
                string[] token = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (token[0] == "END") break;

                if (token[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (token.Length > 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int x1 = int.Parse(token[1]);
                int y1 = int.Parse(token[2]);
                int x2 = int.Parse(token[3]);
                int y2 = int.Parse(token[4]);

                if (x1 < 0 || x1 >= rows
                 || y1 < 0 || y1 >= cols
                 || x2 < 0 || x2 >= rows
                 || y2 < 0 || y2 >= cols)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string firstElement = matrix[x1][y1];
                string secondElement = matrix[x2][y2];

                matrix[x1][y1] = secondElement;
                matrix[x2][y2] = firstElement;

                foreach (var thing in matrix)
                {
                    Console.WriteLine(string.Join(" ", thing));
                }

            }
        }
    }
}
