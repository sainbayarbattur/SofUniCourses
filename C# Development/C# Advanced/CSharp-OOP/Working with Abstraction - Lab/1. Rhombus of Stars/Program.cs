namespace _1RhombusofStars
{
    using System;

    public class Program
    {
        const char symbol = '*';

        private static int count;

        public static void Main()
        {
            count = int.Parse(Console.ReadLine());

            for (int i = 0; i <= count; i++)
            {
                PrintRow(i);
            }

            for (int i = count - 1; i >= 0; i--)
            {
                PrintRow(i);
            }
        }

        public static void PrintRow(int n)
        {
            string line = new string(' ', count - n);

            for (int i = 0; i < n; i++)
            {
                line += symbol + " ";
            }

            Console.WriteLine(line);
        }
    }
}