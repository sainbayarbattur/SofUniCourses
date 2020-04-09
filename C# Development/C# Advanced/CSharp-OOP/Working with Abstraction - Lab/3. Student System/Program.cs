namespace _3StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            var students = new List<Student>();

            while (line != "Exit")
            {
                string command = line.Split(' ')[0];

                string studentName = line.Split(' ')[1];

                if (command == "Show")
                {
                    Console.WriteLine(students.Find(s => s.Name == studentName));
                }
                else if (command == "Create" && students.Find(s => s.Name == studentName) == null){
                    int studentAge = int.Parse(line.Split(' ')[2]);

                    double studentGrade = double.Parse(line.Split(' ')[3]);

                    var student = new Student(studentName, studentAge, studentGrade);

                    students.Add(student);
                }

                line = Console.ReadLine();
            }
        }
    }
}