namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var listOfCitizens = new List<IId>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End") break;

                string[] token = input.Split(' ');

                if (token.Length == 3)
                {
                    string name = token[0];
                    int age = int.Parse(token[1]);
                    string id = token[2];

                    var citizen = new Citizen(name, age, id);
                    listOfCitizens.Add(citizen);
                }
                else if (token.Length == 2)
                {
                    string name = token[0];
                    string id = token[1];

                    var robot = new Robot(name, id);
                    listOfCitizens.Add(robot);
                }
            }

            string lastThreeDigits = Console.ReadLine();

            listOfCitizens = listOfCitizens.Where(x => x.Id.Substring(x.Id.Length - lastThreeDigits.Length, lastThreeDigits.Length) == lastThreeDigits).ToList();

            foreach (var invalidId in listOfCitizens)
            {
                Console.WriteLine(invalidId.Id);
            }
        }
    }
}