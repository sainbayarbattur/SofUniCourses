namespace NxNMatrix
{
    using System;
    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            PrintNxNMatrix(number);
            Console.Read();
        }

        public static void PrintNxNMatrix(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int b = 0; b < n; b++)
                {
                    Console.Write(n + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
