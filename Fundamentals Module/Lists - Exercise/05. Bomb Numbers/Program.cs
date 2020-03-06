namespace BombNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> bombPro = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int bomb = bombPro[0];
            int power = bombPro[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];

                if (currentNumber == bomb)
                {
                    int firstIndex = i - power;
                    int lastIndex = i + power;

                    if (firstIndex < 0)
                    {
                        firstIndex = 0;
                    }
                    if (lastIndex > numbers.Count - 1)
                    {
                        lastIndex = numbers.Count - 1;
                    }
                    if (firstIndex > numbers.Count - 1 || lastIndex < 0)
                    {
                        continue;
                    }

                    numbers.RemoveRange(firstIndex, lastIndex - firstIndex + 1);

                    i = firstIndex - 1;
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
