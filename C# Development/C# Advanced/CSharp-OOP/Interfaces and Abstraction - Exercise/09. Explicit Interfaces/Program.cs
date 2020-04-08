namespace Problem9ExplicitInterfaces
{
    using Problem9ExplicitInterfaces.Contracts;
    using Problem9ExplicitInterfaces.Model;
    using System;
    public class Program
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] personData = line.Split(" ");

                string name = personData[0];
                string country = personData[1];
                int age = int.Parse(personData[2]);

                IPerson person = new Citizen(name, country, age);

                IResident resident = new Citizen(name, country, age);

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName() + person.GetName());

                line = Console.ReadLine();
            }
        }
    }
}