using System;

namespace ConsoleApp64
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int strongNumber = number;
            int digit = 0;
            int factorial = 1;
            int sum = 0;

            while (number != 0)
            {
                digit = number % 10;
                number /= 10;

                for (int i = 1; i <= digit; i++)
                {
                    factorial *= i;
                }

                sum += factorial;
                factorial = 1;
            }

            if (sum == strongNumber)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

            Console.Read();
        }
    }
}
