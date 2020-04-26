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
                Console.WriteLine(DeleteProjectById(context));
            }
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var result = new StringBuilder();

            var projectToDelete = context.Projects
                .Find(2);

            var employeesProjectToDelete = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2);

            foreach (var employeeProject in employeesProjectToDelete)
            {
                context.EmployeesProjects.Remove(employeeProject);
            }

            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            var projects = context.Projects
                .Select(p => p.Name)
                .Take(10);

            foreach (var project in projects)
            {
                result.AppendLine(project);
            }

            return result.ToString();
        }
    }
}
