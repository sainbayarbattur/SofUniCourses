using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int b = 0; b < n; b++)
                {
                    for (int c = 0; c < n; c++)
                    {
                        char first = (char)('a' + i);
                        char second = (char)('a' + b);
                        char third = (char)('a' + c);
                        Console.WriteLine(first.ToString() + second + third);
                    }
                }
            }
        }
    }
}
