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
                Console.WriteLine(GetCarsWithTheirListOfParts(db));
            }
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new CarPartsDTO
                {
                    Car = new CarDTO
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },

                    Parts = c.PartCars
                        .Select(p => new PartDTO
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price.ToString("f2")
                        })
                        .ToList()
                })
                .ToList();

            var carsJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return carsJson;
        }
    }
}