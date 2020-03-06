namespace StudentAcademy
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var result = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double score = double.Parse(Console.ReadLine());

                if (!result.ContainsKey(name))
                {
                    result.Add(name, new List<double>());
                }
                result[name].Add(score);
            }

            result = result.Where(x => x.Value.Average() >= 4.50).ToDictionary(k => k.Key, v => v.Value);
            foreach (var item in result.OrderByDescending(x => x.Value.Average()))
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
            }
        }
    }
}
