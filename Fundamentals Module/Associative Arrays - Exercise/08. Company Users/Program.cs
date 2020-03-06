namespace Force
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var result = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End") break;

                string[] token = input.Split(" -> ");

                string name = token[0];

                string id = token[1];

                if (!result.ContainsKey(name))
                {
                    result.Add(name, new List<string>());
                }
                if (!result[name].Contains(id)) result[name].Add(id);
            }

            foreach (var item in result.OrderBy(x=>x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var value in item.Value)
                {
                    Console.WriteLine("-- " + value);
                }
            }
        }
    }
}
