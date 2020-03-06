namespace MagicSum
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

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int b = i + 1; b < numbers.Length; b++)
                {
                    if (numbers[i] + numbers[b] == n)
                    {
                        Console.WriteLine(numbers[i] + " " + numbers[b]);
                    }
                }
            }

            Console.Read();
        }
    }
}
