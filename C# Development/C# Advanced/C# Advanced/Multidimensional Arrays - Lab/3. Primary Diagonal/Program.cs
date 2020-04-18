namespace _3._Primary_Diagonal
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            int[][] matrix = new int[n][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }

            for (int i = 0; i < n; i++)
            {
                sum += matrix[i][i];
            }

            Console.WriteLine(sum);
        }
    }
}