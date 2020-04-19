namespace _6._Jagged_Array_Manipulator
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] matrix = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    MultiplyRowsBy2(matrix, new int[] { row, row + 1 });
                }
                else
                {
                    DivideRowsBy2(matrix, new int[] { row, row + 1 });
                }
            }

            string line = Console.ReadLine();

            while (line != "End")
            {
                string command = line.Split(' ')[0];
                int[] args = line.Split(' ').Where((e, i) => i != 0).Select(int.Parse).ToArray();

                if (args[0] >= 0 && args[0] < rows && args[1] >= 0 && args[1] < matrix[args[0]].Length)
                {
                    if (command == "Subtract")
                    {
                        matrix[args[0]][args[1]] -= args[2];
                    }
                    else if (command == "Add")
                    {
                        matrix[args[0]][args[1]] += args[2];
                    }
                }

                line = Console.ReadLine();
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(' ', matrix[row]));
            }
        }

        public static void MultiplyRowsBy2(double[][] matrix, int[] rows)
        {
            for (int r = 0; r < rows.Length; r++)
            {
                int currRow = rows[r];

                for (int c = 0; c < matrix[currRow].Length; c++)
                {
                    matrix[currRow][c] *= 2;
                }
            }
        }

        public static void DivideRowsBy2(double[][] matrix, int[] rows)
        {
            for (int r = 0; r < rows.Length; r++)
            {
                int currRow = rows[r];

                for (int c = 0; c < matrix[currRow].Length; c++)
                {
                    matrix[currRow][c] /= 2;
                }
            }
        }
    }
}