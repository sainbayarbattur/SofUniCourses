namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int row = input[0];
            int col = input[1];

            char[,] matrix = new char[row, col];
            var isPlayerDead = false;

            for (int i = 0; i < row; i++)
            {
                var currCol = Console.ReadLine().ToCharArray();
                for (int b = 0; b < col; b++)
                {
                    matrix[i, b] = currCol[b];
                }
            }

            int[] playerCoordinates = new int[2];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int b = 0; b < matrix.GetLength(1); b++)
                {
                    if (matrix[i, b] == 'P')
                    {
                        playerCoordinates[0] = i;
                        playerCoordinates[1] = b;
                    }
                }
            }

            var commands = Console.ReadLine().ToCharArray();

            int playerRow = -1;
            int playerCol = -1;

            for (int i = 0; i < commands.Length; i++)
            {
                playerRow = playerCoordinates[0];
                playerCol = playerCoordinates[1];

                matrix[playerRow, playerCol] = '.';

                FindingBunny(matrix);

                if (commands[i] == 'L')
                {
                    if (playerCol - 1 < 0)
                    {
                        isPlayerDead = false;
                        break;
                    }

                    playerCol--;

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        isPlayerDead = true;
                        break;
                    }
                }
                else if (commands[i] == 'U')
                {
                    if (playerRow - 1 < 0)
                    {
                        isPlayerDead = false;
                        break;
                    }

                    playerRow--;

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        isPlayerDead = true;
                        break;
                    }
                }
                else if (commands[i] == 'D')
                {
                    if (playerRow + 1 > matrix.GetLength(0) - 1)
                    {
                        isPlayerDead = false;
                        break;
                    }

                    playerRow++;

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        isPlayerDead = true;
                        break;
                    }
                }
                else if (commands[i] == 'R')
                {
                    if (playerCol + 1 > matrix.GetLength(1) - 1)
                    {
                        isPlayerDead = false;
                        break;
                    }

                    playerCol++;

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        isPlayerDead = true;
                        break;
                    }
                }

                playerCoordinates[0] = playerRow;
                playerCoordinates[1] = playerCol;
            }

            PrintMatrix(matrix);

            if (isPlayerDead)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static void FindingBunny(char[,] matrix)
        {
            var mutedBunnies = new List<int[]>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        mutedBunnies.Add(new int[] { row, col });
                    }
                }
            }

            foreach (var mutaedBunny in mutedBunnies)
            {
                MutatingBunny(matrix, mutaedBunny[0], mutaedBunny[1]);
            }
        }

        private static void MutatingBunny(char[,] matrix, int row, int col)
        {
            int rowLength = matrix.GetLength(0) - 1;
            int colLength = matrix.GetLength(1) - 1;

            if (row + 1 <= rowLength)
            {
                matrix[row + 1, col] = 'B';
            }
            if (col + 1 <= colLength)
            {
                matrix[row, col + 1] = 'B';
            }
            if (row - 1 >= 0)
            {
                matrix[row - 1, col] = 'B';
            }
            if (col - 1 >= 0)
            {
                matrix[row, col - 1] = 'B';
            }
        }
    }
}