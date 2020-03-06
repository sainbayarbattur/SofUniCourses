namespace Students
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public class Student
        {
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public double Grade { get; set; }

            public Student(string firstName, string secondName, double grade)
            {
                FirstName = firstName;
                SecondName = secondName;
                Grade = grade;
            }
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var currStudent = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToList();
                string firstName = input[0];
                string secondName = input[1];
                double grade = double.Parse(input[2]);
                var curr = new Student(firstName, secondName, grade);
                currStudent.Add(curr);
            }

            foreach (var item in currStudent.OrderByDescending(x=>x.Grade))
            {
                Console.WriteLine($"{item.FirstName} {item.SecondName}: {item.Grade:f2}");
            }
        }
    }
}
