namespace TopIntegers
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            int[] num = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] result = new int[num.Length];
            int length = num.Length;

            for (int i = 0; i < length; i++)
            {
                int firstNumber = num[i];
                for (int b = i + 1; b < length; b++)
                {
                    int secondNumber = num[b];
                    if (firstNumber <= secondNumber)
                    {
                        break;
                    }
                    else if (b == num.Length - 1)
                    {
                        Console.Write(firstNumber + " ");
                    }
                }
            }
            Console.WriteLine(num[num.Length - 1]);
            Console.Read();
        }
    }
}
