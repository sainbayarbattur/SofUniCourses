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
                Console.WriteLine(GetLocalSuppliers(db));
            }
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var cars = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new ExportLocalSuppliersDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count,
                })
                .ToArray();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var serializer = new XmlSerializer(typeof(ExportLocalSuppliersDTO[]), new XmlRootAttribute("suppliers"));

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, cars, ns);

                var productsXml = writer.GetStringBuilder();

                return productsXml.ToString().TrimEnd();
            }
        }
    }
}