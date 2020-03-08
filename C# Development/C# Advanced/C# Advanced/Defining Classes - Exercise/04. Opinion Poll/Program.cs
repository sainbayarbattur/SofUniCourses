namespace Problem_4._Opinion_Poll
{
    using DefiningClasses;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var person = new Person();

            var result = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string currInput = Console.ReadLine();

                string[] token = currInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = token[0];

                int age = int.Parse(token[1]);

                person = new Person
                {
                    Name = name,
                    Age = age,
                };

                result.Add(person);
            }

            foreach (var _person in result.Where(x => x.Age > 30).OrderBy(x => x.Name))
            {
                Console.WriteLine($"{_person.Name} - {_person.Age}");
            }
        }
    }
}
