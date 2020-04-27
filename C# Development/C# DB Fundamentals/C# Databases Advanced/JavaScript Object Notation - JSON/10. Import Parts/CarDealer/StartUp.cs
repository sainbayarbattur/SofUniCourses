using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
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
                var input = File.ReadAllText("./../../../Datasets/parts.json");

                Console.WriteLine(ImportParts(db, input));
            }
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var json = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToList();

            context.Parts.AddRange(json);
            context.SaveChanges();

            return $"Successfully imported {json.Count}."; ;
        }
    }
}