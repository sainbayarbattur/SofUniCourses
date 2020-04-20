namespace _02._Average_Student_Grades
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var studentRecord = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                string name = line[0];
                double grade = double.Parse(line[1]);

                if (!studentRecord.ContainsKey(name))
                {
                    studentRecord.Add(name, new List<double>());
                }

                if(studentRecord.ContainsKey(name))
                {
                    studentRecord[name].Add(grade);
                }
            }

            foreach (var student in studentRecord)
            {
                var grades = new List<string>();

                foreach (var grade in student.Value)
                {
                    grades.Add(grade.ToString("f2"));
                }

                Console.WriteLine($"{student.Key} -> {string.Join(' ', grades)} (avg: {student.Value.Average():f2})");
            }
        }
    }
}