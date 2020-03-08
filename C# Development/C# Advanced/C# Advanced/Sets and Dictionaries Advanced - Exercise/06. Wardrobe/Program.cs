namespace Wardrobe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var result = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var currInput = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (!result.ContainsKey(currInput[0]))
                {
                    result.Add(currInput[0], new Dictionary<string, int>());
                }

                for (int b = 1; b < currInput.Count; b++)
                {
                    if (!result[currInput[0]].ContainsKey(currInput[b]))
                    {
                        result[currInput[0]].Add(currInput[b], 0);
                    }

                    result[currInput[0]][currInput[b]]++;
                }
            }

            string[] search = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var colors in result)
            {
                Console.WriteLine(colors.Key + " clothes:");
                foreach (var item in colors.Value)
                {
                    if (colors.Key == search[0] && item.Key == search[1])
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}