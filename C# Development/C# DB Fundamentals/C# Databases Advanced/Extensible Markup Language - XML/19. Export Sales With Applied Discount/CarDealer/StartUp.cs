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
                Console.WriteLine(GetSalesWithAppliedDiscount(db));
            }
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var cars = context.Sales
                .Select(c => new ExportSalesWithAppliedDiscountDTO
                {
                    Car = new ExportCarDTO
                    {
                        Make = c.Car.Make,
                        Model = c.Car.Model,
                        TravelledDistance = c.Car.TravelledDistance
                    },
                    Discount = c.Discount,
                    CustomerName = c.Customer.Name,
                    Price = c.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = c.Car.PartCars.Sum(pc => pc.Part.Price) -
                c.Car.PartCars.Sum(pc => pc.Part.Price)
                * c.Discount / 100
                })
                .ToArray();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var serializer = new XmlSerializer(typeof(ExportSalesWithAppliedDiscountDTO[]), new XmlRootAttribute("sales"));

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, cars, ns);

                var productsXml = writer.GetStringBuilder();

                return productsXml.ToString().TrimEnd();
            }
        }
    }
}