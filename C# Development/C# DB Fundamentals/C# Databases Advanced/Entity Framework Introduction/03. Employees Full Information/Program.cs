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
                Console.WriteLine(GetEmployeesFullInformation(context));
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var result = new StringBuilder();

            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .ToList();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:0.00}");
            }

            return result.ToString();
        }
    }
}
