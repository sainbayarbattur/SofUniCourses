using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                Console.WriteLine(GetEmployeesWithSalaryOver50000(context));
            }
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var result = new StringBuilder();

            var employees = context.Employees
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName)
                .ToList();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} - {employee.Salary:0.00}");
            }

            return result.ToString();
        }
    }
}
