using System;

namespace ConsoleApp60
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int b = 1; b <= i; b++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }

            Console.Read();
        }
    }
}
