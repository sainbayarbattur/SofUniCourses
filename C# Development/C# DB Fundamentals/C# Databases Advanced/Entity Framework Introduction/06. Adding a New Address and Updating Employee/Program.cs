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
                Console.WriteLine(AddNewAddressToEmployee(context));
            }
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var result = new StringBuilder();

            var addressToAdd = new Address() { AddressText = "Vitoshka 15", TownId = 4 };

            context.Addresses.Add(addressToAdd);

            var employee = context.Employees.First(e => e.LastName == "Nakov");

            employee.Address = addressToAdd;

            context.SaveChanges();

            var employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToList();

            foreach (var item in employees)
            {
                result.AppendLine($"{item}");
            }

            return result.ToString();
        }
    }
}
