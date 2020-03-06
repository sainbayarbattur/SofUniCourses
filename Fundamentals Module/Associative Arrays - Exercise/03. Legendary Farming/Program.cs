using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Dictionary<string, int>
            {
                ["fragments"] = 0,
                ["shards"] = 0,
                ["motes"] = 0
            };

            while (true)
            {
                List<string> current = Console.ReadLine().Split(' ').ToList();

                for (int i = 0; i < current.Count; i += 2)
                {

                    int currNum = int.Parse(current[i]);

                    string currMat = current[i + 1].ToLower();

                    if (!result.ContainsKey(currMat))
                    {
                        result.Add(currMat, 0);
                    }
                    result[currMat] += currNum;

                    if (result["fragments"] >= 250)
                    {
                        Console.WriteLine("Valanyr obtained!");
                        result["fragments"] -= 250;

                        PrintLeftProducts(result);
                        return;
                    }
                    else if (result["shards"] >= 250)
                    {
                        Console.WriteLine("Shadowmourne obtained!");
                        result["shards"] -= 250;

                        PrintLeftProducts(result);
                        return;
                    }
                    else if (result["motes"] >= 250)
                    {
                        Console.WriteLine("Dragonwrath obtained!");
                        result["motes"] -= 250;

                        PrintLeftProducts(result);
                        return;
                    }

                }

            }
        }

        private static void PrintLeftProducts(Dictionary<string, int> result)
        {
            foreach (var material in result
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                string keyMaterial = material.Key;
                if (material.Key == "shards" || material.Key == "motes" || material.Key == "fragments")
                {
                    Console.WriteLine("{0}: {1}", material.Key, material.Value);
                }

            }
            List<string> keys = new List<string> { "fragments", "shards", "motes" };

            foreach (var material in result
                .OrderBy(x => x.Key))
            {
                if (!keys.Contains(material.Key))
                {
                    Console.WriteLine("{0}: {1}", material.Key, material.Value);
                }

            }
        }
    }
}