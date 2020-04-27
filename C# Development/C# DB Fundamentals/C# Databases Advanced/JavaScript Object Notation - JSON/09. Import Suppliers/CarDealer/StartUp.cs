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
                var input = Console.ReadLine();

                Console.WriteLine(ImportSuppliers(db, input));
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var json = JsonConvert.DeserializeObject<Supplier[]>(inputJson).ToList();

            context.Suppliers.AddRange(json);
            context.SaveChanges();

            return $"Successfully imported {json.Count}."; ;
        }
    }
}