namespace Miner
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            int countCoal = 0;

            char[,] matrix = new char[n, n];

            int allCoals = 0;

            for (int row = 0; row < n; row++)
            {
                char[] currRow = Console.ReadLine().Replace(" ", "").ToCharArray();

                for (int col = 0; col < currRow.Length; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'c')
                    {
                        allCoals++;
                    }
                }
            }

            int[] coordinates = GetStartingPoint(matrix);

            for (int i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "up":
                        if (IsInMatrix(matrix, coordinates, commands[i]))
                        {
                            coordinates[0]--;
                            char currChar = WhatYouFind(coordinates, matrix);
                            if (Sequences(currChar, matrix, coordinates, countCoal, allCoals))
                            {
                                return;
                            }
                            matrix[coordinates[0], coordinates[1]] = '*';

                            if (currChar == 'c')
                            {
                                countCoal++;

                                if (countCoal == allCoals)
                                {
                                    Console.WriteLine($"You collected all coals! ({coordinates[0]}, {coordinates[1]})");
                                    return;
                                }
                            }
                        }
                        break;
                    case "down":
                        if (IsInMatrix(matrix, coordinates, commands[i]))
                        {
                            coordinates[0]++;
                            char currChar = WhatYouFind(coordinates, matrix);
                            if (Sequences(currChar, matrix, coordinates, countCoal, allCoals))
                            {
                                return;
                            }
                            matrix[coordinates[0], coordinates[1]] = '*';

                            if (currChar == 'c')
                            {
                                countCoal++;

                                if (countCoal == allCoals)
                                {
                                    Console.WriteLine($"You collected all coals! ({coordinates[0]}, {coordinates[1]})");
                                    return;
                                }
                            }
                        }
                        break;
                    case "right":
                        if (IsInMatrix(matrix, coordinates, commands[i]))
                        {
                            coordinates[1]++;
                            char currChar = WhatYouFind(coordinates, matrix);
                            if (Sequences(currChar, matrix, coordinates, countCoal, allCoals))
                            {
                                return;
                            }
                            matrix[coordinates[0], coordinates[1]] = '*';

                            if (currChar == 'c')
                            {
                                countCoal++;

                                if (countCoal == allCoals)
                                {
                                    Console.WriteLine($"You collected all coals! ({coordinates[0]}, {coordinates[1]})");
                                    return;
                                }
                            }
                        }
                        break;
                    case "left":
                        if (IsInMatrix(matrix, coordinates, commands[i]))
                        {
                            coordinates[1]--;
                            char currChar = WhatYouFind(coordinates, matrix);
                            if (Sequences(currChar, matrix, coordinates, countCoal, allCoals))
                            {
                                return;
                            }
                            matrix[coordinates[0], coordinates[1]] = '*';

                            if (currChar == 'c')
                            {
                                countCoal++;

                                if (countCoal == allCoals)
                                {
                                    Console.WriteLine($"You collected all coals! ({coordinates[0]}, {coordinates[1]})");
                                    return;
                                }
                            }
                        }
                        break;
                }
            }

            Console.WriteLine($"{allCoals - countCoal} coals left. ({coordinates[0]}, {coordinates[1]})");
        }

        private static bool Sequences(char currChar, char[,] matrix, int[] coordinates, int countCoal, int allCoals)
        {
            if (currChar == 'e')
            {
                Console.WriteLine($"Game over! ({coordinates[0]}, {coordinates[1]})");
                return true;
            }
            else
            {
                return false;
            }
        }

        private static char WhatYouFind(int[] coordinates, char[,] matrix)
        {
            char currChar = matrix[coordinates[0], coordinates[1]];

            return currChar;
        }

        private static bool IsInMatrix(char[,] matrix, int[] coordinates, string direction)
        {
            bool isInMatrix = false;

            int[] futureCoordinations = new int[2];

            switch (direction)
            {
                case "up":
                    futureCoordinations[0] = coordinates[0] - 1;
                    futureCoordinations[1] = coordinates[1];

                    if (futureCoordinations[0] < 0)
                    {
                        isInMatrix = false;
                    }
                    else
                    {
                        isInMatrix = true;
                    }
                    break;
                case "down":
                    futureCoordinations[0] = coordinates[0] + 1;
                    futureCoordinations[1] = coordinates[1];

                    if (futureCoordinations[0] > matrix.GetLength(0) - 1)
                    {
                        isInMatrix = false;
                    }
                    else
                    {
                        isInMatrix = true;
                    }
                    break;
                case "right":
                    futureCoordinations[0] = coordinates[0];
                    futureCoordinations[1] = coordinates[1] + 1;

                    if (futureCoordinations[1] > matrix.GetLength(1) - 1)
                    {
                        isInMatrix = false;
                    }
                    else
                    {
                        isInMatrix = true;
                    }
                    break;
                case "left":
                    futureCoordinations[0] = coordinates[0];
                    futureCoordinations[1] = coordinates[1] - 1;

                    if (futureCoordinations[1] < 0)
                    {
                        isInMatrix = false;
                    }
                    else
                    {
                        isInMatrix = true;
                    }
                    break;
            }

            return isInMatrix;
        }

        public static int[] GetStartingPoint(char[,] matrix)
        {
            int[] coordinates = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        coordinates[0] = row;
                        coordinates[1] = col;
                        break;
                    }
                }
            }

            return coordinates;
        }
    }
}
