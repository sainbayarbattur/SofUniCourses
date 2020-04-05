using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class Potato
    {
        public static void Main()
        {
            long input = long.Parse(Console.ReadLine());
            string[] treasure = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long stones = 0;
            long money = 0;

            for (int i = 0; i < treasure.Length; i += 2)
            {
                string name = treasure[i];
                long count = long.Parse(treasure[i + 1]);

                string whatIsIt = string.Empty;

                if (name.Length == 3)
                {
                    whatIsIt = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    whatIsIt = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    whatIsIt = "Gold";
                }

                if (whatIsIt == "" || input < bag.Values.Select(x => x.Values.Sum()).Sum() + count)
                {
                    continue;
                }

                switch (whatIsIt)
                {
                    case "Gem":
                        if (!bag.ContainsKey(whatIsIt))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (count > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[whatIsIt].Values.Sum() + count > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(whatIsIt))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (count > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[whatIsIt].Values.Sum() + count > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(whatIsIt))
                {
                    bag[whatIsIt] = new Dictionary<string, long>();
                }

                if (!bag[whatIsIt].ContainsKey(name))
                {
                    bag[whatIsIt][name] = 0;
                }

                bag[whatIsIt][name] += count;
                if (whatIsIt == "Gold")
                {
                    gold += count;
                }
                else if (whatIsIt == "Gem")
                {
                    stones += count;
                }
                else if (whatIsIt == "Cash")
                {
                    money += count;
                }
            }

            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var values in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{values.Key} - {values.Value}");
                }
            }
        }
    }
}