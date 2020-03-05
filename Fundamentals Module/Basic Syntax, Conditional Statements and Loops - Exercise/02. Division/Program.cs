using System;

namespace ConsoleApp58
{
    public class Program
    {
        static public void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int secondD = 0;
            int thirdD = 0;
            int sixthD = 0;
            int seventhD = 0;
            int tenthD = 0;

            if (number % 2 == 0)
            {
                secondD = 2;
            }
            if (number % 3 == 0)
            {
                thirdD = 3;
            }
            if (number % 6 == 0)
            {
                sixthD = 6;
            }
            if (number % 7 == 0)
            {
                seventhD = 7;
            }
            if (number % 10 == 0)
            {
                tenthD = 10;
            }

            if (tenthD == 10)
            {
                Console.WriteLine("The number is divisible by 10");
            }
            else if (seventhD == 7)
            {
                Console.WriteLine("The number is divisible by 7");
            }
            else if (sixthD == 6)
            {
                Console.WriteLine("The number is divisible by 6");
            }
            else if (thirdD == 3)
            {
                Console.WriteLine("The number is divisible by 3");
            }
            else if (secondD == 2)
            {
                Console.WriteLine("The number is divisible by 2");
            }

            if (secondD == 0 && thirdD == 0 && sixthD == 0 && seventhD == 0 && tenthD == 0)
            {
                Console.WriteLine("Not divisible");
            }

            Console.Read();
        }
    }
}
