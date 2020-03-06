namespace AppendArrays
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            List<string> numbers = Console.ReadLine()
                .Split('|')
                .ToList();

            List<int> result = new List<int>();

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                int[] currentArr = numbers[i]
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int b = 0; b < currentArr.Length; b++)
                {
                    result.Add(currentArr[b]);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
