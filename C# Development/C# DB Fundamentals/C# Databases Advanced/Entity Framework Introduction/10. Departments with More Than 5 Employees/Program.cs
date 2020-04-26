using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
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
                Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));
            }
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var result = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .Select(d =>
                new
                {
                    d.Name,
                    MLastName = d.Manager.LastName,
                    MFirstName = d.Manager.FirstName,
                    d.Employees,
                }
                )
                .ToList();

            foreach (var department in departments)
            {
                Console.WriteLine($"{department.Name} - {department.MFirstName} {department.MLastName}");

                foreach (var employee in department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    Console.WriteLine(employee.FirstName + " " + employee.LastName + " - " + employee.JobTitle);
                }
            }

            return result.ToString();
        }
    }
}
