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
                Console.WriteLine(GetTotalSalesByCustomer(db));
            }
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var cars = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new ExportTotalSalesByCustomerDTO
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SpentMoney = c.Sales.Select(s => s.Car.PartCars.Sum(pc => pc.Part.Price)).Sum()
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var serializer = new XmlSerializer(typeof(ExportTotalSalesByCustomerDTO[]), new XmlRootAttribute("customers"));

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, cars, ns);

                var productsXml = writer.GetStringBuilder();

                return productsXml.ToString().TrimEnd();
            }
        }
    }
}