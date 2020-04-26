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
                Console.WriteLine(GetEmployeesInPeriod(context));
            }
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var result = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.EmployeesProjects
                .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select
                (e => new
                {
                    e.FirstName,
                    e.LastName,
                    MFirstName = e.Manager.FirstName,
                    MLastName = e.Manager.LastName,
                    e.EmployeesProjects,
                    ProjectInfo = e.EmployeesProjects.Select(ep => ep.Project)
                }
                )
                .Take(10)
                .ToList();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.MFirstName} {employee.MLastName}");

                foreach (var project in employee.ProjectInfo)
                {
                    string endDate = project.EndDate.ToString();

                    if (endDate == string.Empty)
                    {
                        endDate = "not finished";
                    }

                    result.AppendLine($"--{project.Name} - {project.StartDate} - {endDate}");
                }
            }

            return result.ToString();
        }
    }
}
