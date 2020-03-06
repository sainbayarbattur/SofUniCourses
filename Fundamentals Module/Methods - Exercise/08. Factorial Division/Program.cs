namespace FactorialDivision
{
    using System;
    public class Program
    {
        public static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine(FactorialDivision(a, b).ToString("0.00"));

            Console.Read();
        }

        public static double FactorialDivision(int a, int b)
        {
            double firstResult = 1;
            double secondResult = 1;

            for (int firstFactorial = 2; firstFactorial <= a; firstFactorial++)
            {
                firstResult *= firstFactorial;
            }

            for (int secondFactorial = 2; secondFactorial <= b; secondFactorial++)
            {
                secondResult *= secondFactorial;
            }

            return firstResult / secondResult;
        }
    }
}
