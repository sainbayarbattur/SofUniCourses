namespace TopNumber
{
    using System;
    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                bool result = TopNumeber(i);
                if (result)
                {
                    Console.WriteLine(i);
                }
            }
            Console.Read();
        }

        public static bool TopNumeber(int a)
        {
            int digit = 0;
            bool isOddDigits = false;
            bool result = false;

            while (a != 0)
            {
                digit += a % 10;
                a /= 10;

                if (digit % 2 != 0)
                {
                    isOddDigits = true;
                }
            }

            if (digit % 8 == 0 && isOddDigits)
            {
                result = true;
            }
            return result;
        }
    }
}
