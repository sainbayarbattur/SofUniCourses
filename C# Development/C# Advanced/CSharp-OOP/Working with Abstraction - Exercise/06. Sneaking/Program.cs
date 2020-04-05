using System;
using System.Linq;

namespace P06_Sneaking
{
    public class Sneaking
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            int samRow = 0;
            int samCol = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                samCol = Array.IndexOf(matrix[i], 'S');
                if (samCol != -1)
                {
                    samRow = i;
                    break;
                }
            }

            int nikolaiRow = 0;
            int nikolaiCol = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                nikolaiCol = Array.IndexOf(matrix[i], 'N');
                if (nikolaiCol != -1)
                {
                    nikolaiRow = i;
                    break;
                }
            }

            var commands = Console.ReadLine().ToCharArray();

            var sam = new Sam
            {
                X = samRow,
                Y = samCol
            };

            for (int i = 0; i < commands.Length; i++)
            {
                int oldRow = samRow;
                int oldCol = samCol;

                char command = commands[i];

                MovingEnemies(matrix);

                if ((matrix[samRow].Contains('b') && samCol > Array.IndexOf(matrix[samRow], 'b')) || matrix[samRow].Contains('d') && samCol < Array.IndexOf(matrix[samRow], 'd'))
                {
                    matrix[oldRow][oldCol] = '.';
                    matrix[samRow][samCol] = 'X';
                    Console.WriteLine($"Sam died at {samRow}, {samCol}");
                    PrintMatrix(matrix);
                    break;
                }

                switch (command)
                {
                    case 'U': samRow--; break;
                    case 'L': samCol--; break;
                    case 'R': samCol++; break;
                    case 'D': samRow++; break;
                }

                if (matrix[samRow][samCol] == 'b' || matrix[samRow][samCol] == 'd')
                {
                    matrix[oldRow][oldCol] = '.';
                    matrix[samRow][samCol] = 'S';
                }

                if (samRow == nikolaiRow)
                {
                    matrix[samRow][samCol] = 'S';
                    matrix[nikolaiRow][nikolaiCol] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    matrix[oldRow][oldCol] = '.';
                    PrintMatrix(matrix);
                    break;
                }

                matrix[oldRow][oldCol] = '.';
            }
        }

        public static void PrintMatrix(char[][] matrix)
        {
            foreach (var line in matrix)
            {
                Console.WriteLine(string.Join("", line));
            }
        }
        public static void MovingEnemies(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i].Contains('b'))
                {
                    int indexOfTheEnemy = Array.IndexOf(matrix[i], 'b');
                    if (indexOfTheEnemy == matrix[i].Length - 1)
                    {
                        matrix[i][indexOfTheEnemy] = 'd';
                    }
                    else if (indexOfTheEnemy < matrix[i].Length - 1)
                    {
                        matrix[i][indexOfTheEnemy] = '.';
                        matrix[i][++indexOfTheEnemy] = 'b';
                    }
                }
                else if (matrix[i].Contains('d'))
                {
                    int indexOfTheEnemy = Array.IndexOf(matrix[i], 'd');
                    if (indexOfTheEnemy == 0)
                    {
                        matrix[i][indexOfTheEnemy] = 'b';
                    }
                    else if (indexOfTheEnemy > 0)
                    {
                        matrix[i][indexOfTheEnemy] = '.';
                        matrix[i][--indexOfTheEnemy] = 'd';
                    }
                }
            }
        }
    }
}