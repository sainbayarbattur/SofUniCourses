using System;

namespace _02._Recursive_Factorial
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Factorial(int.Parse(Console.ReadLine()), 1));
        }

        public static long Factorial(int n, int sum)
        {
            if (n != 0)
            {
                sum *= n;
                return Factorial(--n, sum);
            }
            return sum;
        }
    }
}
