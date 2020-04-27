using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp : CarDealerContext
    {
        public static void Main()
        {
            using (var db = new CarDealerContext())
            {
                Console.WriteLine(GetOrderedCustomers(db));
            }
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new { c.Name, BirthDate = c.BirthDate.ToString("dd/MM/yyyy"), c.IsYoungDriver })
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }
    }
}