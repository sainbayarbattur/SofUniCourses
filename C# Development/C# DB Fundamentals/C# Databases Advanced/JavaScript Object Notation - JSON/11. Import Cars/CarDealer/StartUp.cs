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
                var input = File.ReadAllText("./../../../Datasets/cars.json");

                Console.WriteLine(ImportCars(db, input));
            }
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carDtos = JsonConvert.DeserializeObject<CarDTO[]>(inputJson);

            foreach (var carDto in carDtos)
            {
                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                context.Cars.Add(car);

                foreach (var partId in carDto.PartsId)
                {
                    var partCar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    if (car.PartCars.FirstOrDefault(pc => pc.PartId == partId) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }

            context.SaveChanges();

            return $"Successfully imported {carDtos.Length}.";
        }
    }
}