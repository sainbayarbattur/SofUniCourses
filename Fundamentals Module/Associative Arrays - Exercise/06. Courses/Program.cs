namespace Courses
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {

            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" : ").ToArray();
                if (input[0] == "end")
                {
                    break;
                }
                string course = input[0];
                string name = input[1];

                if (!result.ContainsKey(course))
                {
                    result.Add(course, new List<string>().ToList());
                }
                result[course].Add(name);
            }

            foreach (var item in result.OrderByDescending(x => x.Value.Count()))
            {
                string courseName = item.Key;
                var names = item.Value;

                Console.WriteLine($"{courseName}: {names.Count}");
                foreach (var collection in names.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {collection}");
                }
            }
        }
    }
}
