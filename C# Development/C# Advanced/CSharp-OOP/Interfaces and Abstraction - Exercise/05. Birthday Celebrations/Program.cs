namespace BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var result = new List<IBirthday>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End") break;

                var tokens = input.Split(' ');

                if (tokens[0] == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string birthdate = tokens[4];

                    result.Add(new Citizen(name, age, birthdate));
                }
                else if (tokens[0] == "Pet")
                {
                    string name = tokens[1];
                    string birthdate = tokens[2];

                    result.Add(new Pet(name, birthdate));
                }
            }

            string year = Console.ReadLine();

            result = result.Where(x => x.Birthdate.Split('/')[2] == year).ToList();

            //if (result.Count == 0)
            //{
            //    Console.WriteLine("<empty output>");
            //    return;
            //}

            foreach (var birthday in result)
            {
                Console.WriteLine(birthday.Birthdate);
            }
        }
    }
}