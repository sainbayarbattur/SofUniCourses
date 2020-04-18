namespace _6._Jagged_Array_Modification
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[][] matrix = new int[n][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }

            string line = Console.ReadLine();

            while (line != "END")
            {
                string command = line.Split(' ')[0];
                int[] args = line.Split(' ').Where((e, i) => i != 0).Select(int.Parse).ToArray();

                if (!IsInMatrix(args[0], args[1], matrix))
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (command == "Add")
                    {
                        matrix[args[0]][args[1]] += args[2];
                    }
                    else if (command == "Subtract")
                    {
                        matrix[args[0]][args[1]] -= args[2];
                    }
                }

                line = Console.ReadLine();
            }

            PrintMatrix(matrix);
        }

        public static void PrintMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(' ', matrix[row]));
            }
        }

        public static bool IsInMatrix(int row, int col, int[][] matrix)
        {
            return row <= matrix.GetLength(0) - 1
                && row >= 0
                && col <= matrix.GetLength(0) - 1
                && col >= 0;
        }
    }
}