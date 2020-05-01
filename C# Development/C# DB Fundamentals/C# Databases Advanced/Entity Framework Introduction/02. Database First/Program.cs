namespace Softuni
{
    using SoftUni.Data;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new SoftUniContext();

            var result = GetEmployeesFullInformation(db);

            Console.WriteLine(result);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees.Select(e => new
            {
                FullName = e.FirstName + ' ' + e.LastName + ' ' + e.MiddleName,
                e.JobTitle, 
                e.Salary,
                e.EmployeeId
            }).OrderBy(e => e.EmployeeId);

            foreach (var employee in employees)
            {
                sb.AppendLine(employee.FullName + " " + employee.JobTitle + ' ' + employee.Salary.ToString("f2"));
            }

            return sb.ToString();
        }
    }
}