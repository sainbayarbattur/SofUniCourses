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
                var input = File.ReadAllText("./../../../Datasets/sales.json");

                Console.WriteLine(ImportSales(db, input));
            }
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var json = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(json);
            context.SaveChanges();

            return $"Successfully imported {json.Count()}.";
        }
    }
}