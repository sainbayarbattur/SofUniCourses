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
                Console.WriteLine(GetCarsFromMakeToyota(db));
            }
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(c => new { c.Id, c.Make, c.Model, c.TravelledDistance })
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }
    }
}