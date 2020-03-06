namespace OrderByAge
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public class People
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public int Age { get; set; }

            public People(string name, int id, int age)
            {
                Name = name;
                Id = id;
                Age = age;
            }
        }

        public static void Main()
        {
            string name = string.Empty;
            int id = 0;
            int age = 0;
            var result = new List<People>();
            while (true)
            {
                var token = Console.ReadLine().Split(' ').ToList();
                if (token[0] == "End")
                {
                    break;
                }
                name = token[0];
                id = int.Parse(token[1]);
                age = int.Parse(token[2]);
                var p = new People(name, id, age);
                result.Add(p);
            }

            foreach (var item in result.OrderBy(x=>x.Age))
            {
                Console.WriteLine($"{item.Name} with ID: {item.Id} is {item.Age} years old.");
            }
        }
    }
}
