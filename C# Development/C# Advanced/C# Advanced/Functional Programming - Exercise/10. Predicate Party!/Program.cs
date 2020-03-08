namespace Problem_10._Predicate_Party_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var guests = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Party!") break;

                string[] token = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = token[0];

                string filterCommand = token[1];

                string criteria = token[2];

                if (command == "Remove")
                {
                    if (filterCommand == "StartsWith")
                    {
                        guests.RemoveAll(x => x.StartsWith(criteria));
                    }
                    else if (filterCommand == "EndsWith")
                    {
                        guests.RemoveAll(x => x.EndsWith(criteria));
                    }
                    else if (filterCommand == "Length")
                    {
                        guests.RemoveAll(x => x.Length == int.Parse(criteria));
                    }
                }
                else if (command == "Double")
                {
                    var guestsToAdd = new List<string>();
                    if (filterCommand == "StartsWith")
                    {
                        guestsToAdd = guests.Where(x => x.StartsWith(criteria)).ToList();
                    }
                    else if (filterCommand == "EndsWith")
                    {
                        guestsToAdd = guests.Where(x => x.EndsWith(criteria)).ToList();
                    }
                    else if (filterCommand == "Length")
                    {
                        guestsToAdd = guests.Where(x => x.Length == int.Parse(criteria)).ToList();
                    }

                    foreach (var name in guestsToAdd)
                    {
                        int index = guests.IndexOf(name);

                        guests.Insert(index + 1, name);
                    }
                }
            }

            Console.WriteLine(guests.Any() ? string.Join(", ", guests) + " are going to the party!" : "Nobody is going to the party!");
        }
    }
}
