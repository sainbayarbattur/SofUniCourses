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
                Console.WriteLine(GetAddressesByTown(context));
            }
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var result = new StringBuilder();

            var addresses = context.Addresses
                .Select(a => new {a.Town.Name,  a.AddressText, a.Employees.Count })
                .OrderByDescending(a => a.Count)
                .ThenBy(a => a.Name)
                .ThenBy(a => a.AddressText)
                .ToList();

            foreach (var address in addresses)
            {
                result.AppendLine($"{address.AddressText}, {address.Name} - {address.Count} employees");
            }

            return result.ToString();
        }
    }
}
