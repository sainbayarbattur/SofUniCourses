namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            using (var db = new CarDealerContext())
            {
                //db.Database.EnsureCreated();

                var input = File.ReadAllText("./../../../Datasets/cars.xml");
                Console.WriteLine(ImportCars(db, input));
            }
        }


        // Problem. 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            ImportCarDTO[] carDtos;
            using (var reader = new StringReader(inputXml))
            {
                var serializer = new XmlSerializer(typeof(ImportCarDTO[]), new XmlRootAttribute("Cars"));
                carDtos = (ImportCarDTO[])serializer.Deserialize(reader);
            }

            foreach (var dto in carDtos)
            {
                var car = new Car
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TravelledDistance = dto.TravelledDistance
                };

                context.Cars.Add(car);

                var partsId = dto.Parts
                    .Distinct()
                    .Select(p => p.Id)
                    .ToArray();

                foreach (var partId in partsId)
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

            return $"Successfully imported {carDtos.Length}";
        }
    }
}