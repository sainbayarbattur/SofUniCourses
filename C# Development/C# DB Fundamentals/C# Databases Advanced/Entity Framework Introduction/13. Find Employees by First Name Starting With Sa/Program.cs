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
                Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));
            }
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var result = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new { e.FirstName, e.LastName, e.JobTitle, e.Salary })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return result.ToString();
        }
    }
}
