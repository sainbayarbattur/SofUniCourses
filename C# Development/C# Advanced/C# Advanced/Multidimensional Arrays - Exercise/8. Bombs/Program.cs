namespace Bombs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            int[] bombsCoordinates;

            int sum = 0;

            int countActiveCells = 0;

            var bombs = new List<int>();

            for (int row = 0; row < n; row++)
            {
                var currInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currInput[col];
                }
            }

            bombsCoordinates = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int i = 0; i < bombsCoordinates.Length - 1; i++)
            {
                bombs.Add(matrix[bombsCoordinates[i], bombsCoordinates[i + 1]]);
                i++;
            }

            for (int i = 0; i < bombsCoordinates.Length - 1; i++)
            {
                int row = bombsCoordinates[i];
                int col = bombsCoordinates[i + 1];

                ToBomb(matrix, row, col, bombs);
                i++;
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        countActiveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {countActiveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    string currMatrix = matrix[row, col] + " ";
                    Console.Write(currMatrix);
                }
                Console.WriteLine();
            }
        }

        public static void ToBomb(int[,] matrix, int bombRow, int bombCol, List<int> bombs)
        {
            if (matrix[bombRow, bombCol] > 0)
            {
                int rowLength = matrix.GetLength(0) - 1;

                if (bombRow + 1 <= rowLength)
                {
                    if (matrix[bombRow + 1, bombCol] > 0)
                    {
                        matrix[bombRow + 1, bombCol] -= matrix[bombRow, bombCol];
                    }
                }

                if (bombCol + 1 <= rowLength)
                {
                    if (matrix[bombRow, bombCol + 1] > 0)
                    {
                        matrix[bombRow, bombCol + 1] -= matrix[bombRow, bombCol];
                    }
                }

                if (bombRow + 1 <= rowLength && bombCol + 1 <= rowLength)
                {
                    if (matrix[bombRow + 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol + 1] -= matrix[bombRow, bombCol];
                    }
                }

                if (bombRow - 1 >= 0)
                {
                    if (matrix[bombRow - 1, bombCol] > 0)
                    {
                        matrix[bombRow - 1, bombCol] -= matrix[bombRow, bombCol];
                    }
                }

                if (bombCol - 1 >= 0)
                {
                    if (matrix[bombRow, bombCol - 1] > 0)
                    {
                        matrix[bombRow, bombCol - 1] -= matrix[bombRow, bombCol];
                    }
                }

                if (bombRow - 1 >= 0 && bombCol - 1 >= 0)
                {
                    if (matrix[bombRow - 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol - 1] -= matrix[bombRow, bombCol];
                    }
                }

                if (bombRow - 1 >= 0 && bombCol + 1 <= rowLength)
                {
                    if (matrix[bombRow - 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol + 1] -= matrix[bombRow, bombCol];
                    }
                }

                if (bombRow + 1 <= rowLength && bombCol - 1 >= 0)
                {
                    if (matrix[bombRow + 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol - 1] -= matrix[bombRow, bombCol];
                    }
                }

                matrix[bombRow, bombCol] = 0;
            }
        }
    }
}
