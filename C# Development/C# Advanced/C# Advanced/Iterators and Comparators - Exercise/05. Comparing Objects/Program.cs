namespace Problem_5._Comparing_Objects
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            var people = new List<Person>();

            while (input != "END")
            {
                string[] token = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = token[0];

                int age = int.Parse(token[1]);

                string town = token[2];

                var person = new Person(name, age, town);

                people.Add(person);

                input = Console.ReadLine();
            }

            int personNumber = int.Parse(Console.ReadLine());

            var currPerson = people[personNumber - 1];

            int equalPeople = 0;
            int notEqualPeople = 0;

            for (int i = 0; i < people.Count; i++)
            {
                if (currPerson.CompareTo(people[i]) == 0)
                {
                    equalPeople++;
                }
                else
                {
                    notEqualPeople++;
                }
            }

            if (equalPeople > 1)
            {
                Console.WriteLine($"{equalPeople} {notEqualPeople} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
