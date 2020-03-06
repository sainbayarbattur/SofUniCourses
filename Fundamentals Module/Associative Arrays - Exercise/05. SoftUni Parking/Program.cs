namespace Force
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var result = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                string function = input[0];

                string name = input[1];

                switch (function)
                {
                    case "register":
                        string hashcode = input[2];
                        if (!result.ContainsKey(name))
                        {
                            result.Add(name, hashcode);
                            Console.WriteLine($"{name} registered {hashcode} successfully");
                            continue;
                        }
                        Console.WriteLine($"ERROR: already registered with plate number {hashcode}");
                        break;
                    case "unregister":
                        if (result.ContainsKey(name))
                        {
                            result.Remove(name);
                            Console.WriteLine($"{name} unregistered successfully");
                            continue;
                        }
                        Console.WriteLine($"ERROR: user {name} not found");
                        break;
                }
            }

            foreach (var item in result)
            {
                string name = item.Key;
                string hashcode = item.Value;
                Console.WriteLine($"{name} => {hashcode}");
            }
        }
    }
}
