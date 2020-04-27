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

                var input = File.ReadAllText("./../../../Datasets/sales.xml");
                Console.WriteLine(ImportSales(db, input));
            }
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportSaleDTO[]), new XmlRootAttribute("Sales"));

            ImportSaleDTO[] saleDtos;

            using (var reader = new StringReader(inputXml))
            {
                saleDtos = ((ImportSaleDTO[])serializer.Deserialize(reader))
                    .Where(s => context.Cars.Any(c => c.Id == s.CarId))
                    .ToArray();
            }

            var sales = Mapper.Map<Sale[]>(saleDtos);

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }
    }
}