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

                var input = File.ReadAllText("./../../../Datasets/customers.xml");
                Console.WriteLine(ImportCustomers(db, input));
            }
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            return "";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            using (var reader = new StringReader(inputXml))
            {
                var serializer = new XmlSerializer(typeof(ImportCustomerDTO[]), new XmlRootAttribute("Customers"));
                var customersDto = (ImportCustomerDTO[])serializer.Deserialize(reader);

                var customers = customersDto
                    .Select(cd => new Customer
                    {
                        Name = cd.Name,
                        BirthDate = cd.BirthDate,
                        IsYoungDriver = cd.IsYoungDriver
                    })
                    .ToList();

                context.Customers.AddRange(customers);
                context.SaveChanges();

                return $"Successfully imported {customers.Count}";
            }
        }
    }
}