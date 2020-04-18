namespace _5._Square_With_Maximum_Sum
{
    using System;
    using System.Linq;

    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; private set; }

        public int Y { get; private set; }
    }

    public class Program
    {
        private static int rows;
        private static int cols;

        public static void Main()
        {
            string[] input = Console.ReadLine().Split(", ");

            rows = int.Parse(input[0]);
            cols = int.Parse(input[1]);

            int[][] matrix = new int[rows][];

            var sum = 0;
            int[,] resultMatrix = new int[2, 2];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            }

            for (int row = rows; row >= 0; row--)
            {
                for (int col = cols; col >= 0; col--)
                {
                    if (IsSquareInMatrix(new Coordinate(row - 1, col - 1), matrix))
                    {
                        var currSum = CalculateMatrix(new Coordinate(row - 1, col - 1), matrix);
                        if (currSum >= sum)
                        {
                            sum = currSum;
                            resultMatrix = SaveMatrix(new Coordinate(row - 1, col - 1), matrix);
                        }
                    }
                }
            }

            PrintMatrix(resultMatrix);
            Console.WriteLine(sum);
        }

        public static bool IsSquareInMatrix(Coordinate coordinate, int[][] matrix)
        {
            return coordinate.X - 1 >= 0
                && coordinate.Y - 1 >= 0;
        }

        public static int CalculateMatrix(Coordinate coordinate, int[][] matrix)
        {
            var sum = matrix[coordinate.X][coordinate.Y - 1] +
                matrix[coordinate.X - 1][coordinate.Y] +
                matrix[coordinate.X - 1][coordinate.Y - 1] +
                matrix[coordinate.X][coordinate.Y];

            return sum;
        }

        public static int[,] SaveMatrix(Coordinate coordinate, int[][] matrix)
        {
            int[,] matrixToReturn = new int[2, 2];

            matrixToReturn[0, 0] = matrix[coordinate.X - 1][coordinate.Y - 1];
            matrixToReturn[0, 1] = matrix[coordinate.X - 1][coordinate.Y];
            matrixToReturn[1, 0] = matrix[coordinate.X][coordinate.Y - 1];
            matrixToReturn[1, 1] = matrix[coordinate.X][coordinate.Y];

            return matrixToReturn;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}