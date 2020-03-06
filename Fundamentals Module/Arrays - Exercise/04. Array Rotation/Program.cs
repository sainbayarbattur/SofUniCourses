namespace ArrayRotation
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();


            int rotation = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotation; i++)
            {
                int firstNumber = numbers[0];
                for (int b = 0; b < numbers.Length - 1; b++)
                {
                    numbers[b] = numbers[b + 1];
                }
                numbers[numbers.Length - 1] = firstNumber;
            }

            Console.WriteLine(string.Join(" ", numbers));
            Console.Read();
        }
    }
}
