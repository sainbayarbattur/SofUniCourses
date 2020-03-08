namespace Knight_Game
{
    using System;
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int rows = n;
            int cols = n;

            char[][] matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            int removedHorses = 0;

            while (true)
            {
                int knightRow = -1;
                int knightCol = -1;
                int maxAttacked = 0;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {

                        if (matrix[row][col] == 'K')
                        {
                            int tempAttack = CountAttack(matrix, row, col);

                            if (tempAttack > maxAttacked)
                            {
                                maxAttacked = tempAttack;
                                knightRow = row;
                                knightCol = col;
                            }
                        }
                    }
                }

                if (maxAttacked > 0)
                {
                    matrix[knightRow][knightCol] = '0';
                    removedHorses++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(removedHorses);
        }

        private static int CountAttack(char[][] matrix, int row, int col)
        {
            int attacks = 0;

            if (IsInMatrix(row - 1, col - 2, matrix.Length) && matrix[row - 1][col - 2] == 'K')
            {
                attacks++;
            }
            if (IsInMatrix(row + 1, col - 2, matrix.Length) && matrix[row + 1][col - 2] == 'K')
            {
                attacks++;
            }
            if (IsInMatrix(row - 1, col + 2, matrix.Length) && matrix[row - 1][col + 2] == 'K')
            {
                attacks++;
            }
            if (IsInMatrix(row + 1, col + 2, matrix.Length) && matrix[row + 1][col + 2] == 'K')
            {
                attacks++;
            }
            if (IsInMatrix(row + 2, col + 1, matrix.Length) && matrix[row + 2][col + 1] == 'K')
            {
                attacks++;
            }
            if (IsInMatrix(row - 2, col + 1, matrix.Length) && matrix[row - 2][col + 1] == 'K')
            {
                attacks++;
            }
            if (IsInMatrix(row + 2, col - 1, matrix.Length) && matrix[row + 2][col - 1] == 'K')
            {
                attacks++;
            }
            if (IsInMatrix(row - 2, col - 1, matrix.Length) && matrix[row - 2][col - 1] == 'K')
            {
                attacks++;
            }

            return attacks;
        }

        private static bool IsInMatrix(int row, int col, int length)
        {
            return row >= 0 && row < length && col >= 0 && col < length;
        }
    }
}
