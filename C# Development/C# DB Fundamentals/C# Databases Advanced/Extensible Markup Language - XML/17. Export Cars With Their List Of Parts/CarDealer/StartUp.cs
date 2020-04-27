namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Dtos.Export;
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
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.AddProfile<CarDealerProfile>();
            //});

            using (var db = new CarDealerContext())
            {
                Console.WriteLine(GetCarsWithTheirListOfParts(db));
            }
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Select(c => new ExportCarsAndPartsDTO
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                    .Select(pc => new ExportPartDTO
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(pc => pc.Price)
                    .ToArray()
                })
                .Take(5)
                .ToArray();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var serializer = new XmlSerializer(typeof(ExportCarsAndPartsDTO[]), new XmlRootAttribute("cars"));

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, cars, ns);

                var productsXml = writer.GetStringBuilder();

                return productsXml.ToString().TrimEnd();
            }
        }
    }
}