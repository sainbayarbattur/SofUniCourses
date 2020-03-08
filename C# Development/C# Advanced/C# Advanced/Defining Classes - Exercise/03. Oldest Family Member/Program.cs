namespace Problem_3._Oldest_Family_Member
{
    using DefiningClasses;
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var person = new Person();

            var family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] token = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = token[0];

                int age = int.Parse(token[1]);

                person = new Person { Name = name, Age = age };

                family.AddMember(person);
            }
            Console.WriteLine(family.GetOldestMember().Name + " " + family.GetOldestMember().Age);
        }
    }
}
