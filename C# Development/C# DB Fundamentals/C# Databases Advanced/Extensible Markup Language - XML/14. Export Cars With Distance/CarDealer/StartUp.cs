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
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            using (var db = new CarDealerContext())
            {
                Console.WriteLine(GetCarsWithDistance(db));
            }
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            var a = Mapper.Map<ExportCarsWithDistanceDTO[]>(cars);

            using (var writer = new StringWriter())
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                var serializer = new XmlSerializer(typeof(ExportCarsWithDistanceDTO[]), new XmlRootAttribute("cars"));

                serializer.Serialize(writer, a, ns);

                var productsXml = writer.GetStringBuilder();

                return productsXml.ToString().TrimEnd();
            }
        }
    }
}