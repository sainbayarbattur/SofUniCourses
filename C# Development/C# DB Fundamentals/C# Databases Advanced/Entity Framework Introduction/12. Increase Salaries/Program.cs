using System;
using System.Linq;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                Console.WriteLine(IncreaseSalaries(context));
            }
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var result = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                || e.Department.Name == "Tool Design"
                || e.Department.Name == "Marketing"
                || e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            employees.Select(e => e.Salary = e.Salary * 1.12m).ToList();

            context.SaveChanges();

            foreach (var employee in employees)
            {
                result.AppendLine(employee.FirstName + " " + employee.LastName + $" (${employee.Salary:f2})");
            }

            return result.ToString();
        }
    }
}
