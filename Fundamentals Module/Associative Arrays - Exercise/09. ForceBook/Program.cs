namespace ForceAgain
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            var result = new Dictionary<string, List<string>>();

            var allUsers = new List<string>().ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Lumpawaroo") break;

                string[] token = input.Split(new string[] { "->", "|" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = string.Empty;

                string side = string.Empty;

                if (input.Contains("|"))
                {
                    name = token[1];
                    side = token[0];

                    name = name.TrimStart(' ');

                    side = side.TrimEnd(' ');

                    if (!result.ContainsKey(side))
                    {
                        result.Add(side, new List<string>().ToList());
                    }

                    if (!allUsers.Contains(name))
                    {
                        allUsers.Add(name);

                        result[side].Add(name);
                    }
                }
                else
                {
                    name = token[0].TrimEnd(' ');
                    side = token[1].TrimStart(' ');

                    if (!result.ContainsKey(side))
                    {
                        result.Add(side, new List<string>().ToList());
                    }

                    if (allUsers.Contains(name))
                    {
                        string key = GetKey(result, name);

                        result[key].Remove(name);
                    }

                    result[side].Add(name);

                    Console.WriteLine($"{name} joins the {side} side!");
                }
            }

            result = result.Where(x => x.Value.Count > 0).ToDictionary(k => k.Key, v => v.Value);

            foreach (var item in result.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                string side = item.Key;

                var users = item.Value.ToList(); 

                Console.WriteLine($"Side: {side}, Members: {users.Count}");

                foreach (var user in users.OrderBy(x=>x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }

        private static string GetKey(Dictionary<string, List<string>> result, string name)
        {
            string key = string.Empty;

            foreach (var item in result)
            {
                string side = item.Key;

                var value = item.Value;

                if (value.Contains(name))
                {
                    key = side;
                }
            }

            return key;
        }
    }
}
