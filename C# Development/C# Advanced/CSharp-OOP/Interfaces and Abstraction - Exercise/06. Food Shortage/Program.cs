namespace FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var result = new Dictionary<string, IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (input == "End") break;

                string[] token = input.Split(' ');

                if (token.Length == 4)
                {
                    string name = token[0];
                    int age = int.Parse(token[1]);
                    string id = token[2];

                    var citizen = new Citizen(name, age, id);

                    result.Add(name, citizen);
                }
                else if (token.Length == 3)
                {
                    string name = token[0];
                    int age = int.Parse(token[1]);
                    string group = token[2];

                    var rebel = new Rebel(name, age, group);

                    result.Add(name, rebel);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End") break;

                if (result.ContainsKey(input))
                {
                    result[input].BuyFood();
                }
            }

            Console.WriteLine(result.Sum(x => x.Value.Food));
        }
    }
}