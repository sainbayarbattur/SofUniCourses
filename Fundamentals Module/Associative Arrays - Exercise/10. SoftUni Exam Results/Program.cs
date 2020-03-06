namespace SoftUniExamResults
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            var result = new Dictionary<string, int>();
            var countTechnologies = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exam finished")
                {
                    break;
                }
                string name = input.Split('-')[0];
                string technology = input.Split('-')[1];

                if (technology == "banned")
                {
                    if (result.ContainsKey(name))
                    {
                        result = result.Where(x => x.Key != name).ToDictionary(k => k.Key, v => v.Value);
                        countTechnologies = countTechnologies.Where(x => x.Key != name).ToDictionary(k => k.Key, v => v.Value);
                    }
                    break;
                }

                int points = int.Parse(input.Split('-')[2]);

                if (!result.ContainsKey(name))
                {
                    result.Add(name, 0);
                }
                if (result[name] < points)
                {
                    result[name] = points;
                }
                if (!countTechnologies.ContainsKey(technology))
                {
                    countTechnologies.Add(technology, 0);
                }
                countTechnologies[technology] += 1;
            }
            Console.WriteLine("Results:");
            foreach (var item in result.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var item in countTechnologies.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
