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
                Console.WriteLine(GetLatestProjects(context));
            }
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var result = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Select(p => new { p.Name, p.Description, p.StartDate })
                .Take(10)
                .OrderBy(p => p.Name)
                .ToList();

            for (int i = 0; i < projects.Count; i++)
            {
                result.AppendLine(projects[i].Name);
                result.AppendLine(projects[i].Description);
                result.AppendLine(projects[i].StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return result.ToString();
        }
    }
}
