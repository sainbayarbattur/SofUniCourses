namespace SmallestOfThreeNumbers
{
    using System;
    class Program
    {
        static void Main()
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double thirdNumber = double.Parse(Console.ReadLine());

            double smallNumber = SmallerNumber(firstNumber, secondNumber, thirdNumber);

            Console.WriteLine(smallNumber);

            Console.Read();
        }

        public static double SmallerNumber(double a, double b, double c)
        {
            double smallestNumber = 0;

            if (a <= b && a <= c)
            {
                smallestNumber = a;
            }
            else if (b <= a && b < c)
            {
                smallestNumber = b;
            }
            else
            {
                smallestNumber = c;
            }

             return smallestNumber;
        }
    }
}
