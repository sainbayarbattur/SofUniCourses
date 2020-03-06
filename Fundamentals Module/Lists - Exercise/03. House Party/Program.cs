namespace HouseParty
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> peopleWhosGoing = new List<string>();
            List<string> peopleNotInTheList = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string people = Console.ReadLine();
                List<string> lineArgs = people.Split().ToList();
                string person = lineArgs[0];
                if (!lineArgs.Contains("not"))
                {
                    if (!peopleWhosGoing.Contains(person))
                    {
                        peopleWhosGoing.Add(person);
                    }
                    else
                    {
                        Console.WriteLine($"{person} is already in the list!");
                    }
                }
                else
                {
                    if (!peopleWhosGoing.Contains(person))
                    {
                        Console.WriteLine($"{person} is not in the list!");
                    }
                    else
                    {
                        peopleWhosGoing.Remove(person);
                    }
                }
            }

            Console.WriteLine(string.Join("\n", peopleWhosGoing));
        }
    }
}
