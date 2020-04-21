namespace _05._Filter_By_Age
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Format(string format)
        {
            if (format == "name age")
            {
                return this.Name + " - " + this.Age;
            }
            else if (format == "age")
            {
                return this.Age.ToString();
            }
            else
            {
                return this.Name;
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(", ");
                string personName = line[0];
                int personAge = int.Parse(line[1]);

                people[i] = new Person(personName, personAge);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            var filterbyAge = new Func<string, int, List<Person>>((condition, age) =>
            {
                var modifedPeople = new List<Person>();

                for (int i = 0; i < people.Length; i++)
                {
                    if (condition == "younger" && people[i].Age < age)
                    {
                        modifedPeople.Add(people[i]);
                    }
                    else if (condition == "older" && people[i].Age >= age)
                    {
                        modifedPeople.Add(people[i]);
                    }
                }

                return modifedPeople;
            });

            foreach(var person in filterbyAge(condition, age))
            {
                Console.WriteLine(person.Format(format));
            }
        }
    }
}