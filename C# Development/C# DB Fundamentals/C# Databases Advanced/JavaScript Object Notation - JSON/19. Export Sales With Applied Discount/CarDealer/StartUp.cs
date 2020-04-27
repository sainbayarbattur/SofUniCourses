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
                Console.WriteLine(GetSalesWithAppliedDiscount(db));
            }
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new SaleDTO
                {
                    Car = new CarDTO
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = $"{s.Discount:F2}",
                    Price = $"{s.Car.PartCars.Sum(p => p.Part.Price):F2}",
                    PriceWithDiscount = $@"{s.Car.PartCars.Sum(p => p.Part.Price)
                        - s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount / 100:F2}"
                })
                .Take(10)
                .ToList();

            var salesJson = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return salesJson;
        }
    }
}