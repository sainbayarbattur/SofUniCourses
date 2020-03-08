namespace The_V_Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        class Vloger
        {
            public int FollowersCount { get; set; }

            public int FollowingCount { get; set; }

            public List<string> Followers { get; set; }

            public Vloger()
            {
                Followers = new List<string>();
            }
        }

        public static void Main()
        {
            var result = new Dictionary<string, Vloger>();

            int joined = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Statistics") break;

                string[] token = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = token[0];

                string joinOrFollow = token[1];

                string nameOfOther = token[2];

                if (nameOfOther == "The")
                {
                    if (!result.ContainsKey(name))
                    {
                        result.Add(name, new Vloger());
                        joined++;
                    }
                    continue;
                }

                if (result.ContainsKey(nameOfOther) && result.ContainsKey(name))
                {
                    if (!result[nameOfOther].Followers.Contains(name) && name != nameOfOther)
                    {
                        result[nameOfOther].Followers.Add(name);
                        result[nameOfOther].FollowersCount++;
                        result[name].FollowingCount++;
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {joined} vloggers in its logs.");

            int a = 0;

            foreach (var vloger in result.OrderByDescending(x => x.Value.FollowersCount).ThenBy(x => x.Value.FollowingCount))
            {
                a++;
                Console.WriteLine($"{a}. {vloger.Key} : {vloger.Value.FollowersCount} followers, {vloger.Value.FollowingCount} following");
                if (a == 1)
                {
                    foreach (var v in vloger.Value.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {v}");
                    }
                } 
            }
        }
    }
}
