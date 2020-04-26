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
                Console.WriteLine(RemoveTown(context));
            }
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var result = new StringBuilder();

            var townToDelete = context.Towns
                .FirstOrDefault(t => t.Name == "Seattle");

            var addressesInTownSeattleToDelete = context.Addresses
                .Where(a => a.Town == townToDelete)
                .ToList();

            var employeesLivingInNull = context.Employees
                .Where(e => addressesInTownSeattleToDelete.Contains(e.Address))
                .ToList();

            employeesLivingInNull.Select(e => e.AddressId = null).ToList();

            foreach (var addresseInTownSeattleToDelete in addressesInTownSeattleToDelete)
            {
                context.Addresses.Remove(addresseInTownSeattleToDelete);
            }

            context.Towns.Remove(townToDelete);

            context.SaveChanges();

            return $"{addressesInTownSeattleToDelete.Count} addresses in Seattle were deleted";
        }
    }
}
