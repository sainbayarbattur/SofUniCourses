namespace Count_Symbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            char[] input = Console.ReadLine().ToCharArray();

            var result = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currChar = input[i];
                if (!result.ContainsKey(currChar))
                {
                    result.Add(currChar, 0);
                }

                result[currChar]++;
            }

            foreach (var @char in result.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{@char.Key}: {@char.Value} time/s");
            }
        }
    }
}
