namespace DictionariesLambdaAndLINQLabExercise
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            var result = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];

                if (current == ' ')
                {
                    continue;
                }

                if (!result.ContainsKey(current))
                {
                    result.Add(current, 0);
                }

                result[current] += 1;
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
