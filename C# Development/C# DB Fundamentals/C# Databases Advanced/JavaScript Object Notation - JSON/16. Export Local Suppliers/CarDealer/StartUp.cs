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
                Console.WriteLine(GetLocalSuppliers(db));
            }
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var cars = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new { s.Id, s.Name, PartsCount = s.Parts.Count })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }
    }
}