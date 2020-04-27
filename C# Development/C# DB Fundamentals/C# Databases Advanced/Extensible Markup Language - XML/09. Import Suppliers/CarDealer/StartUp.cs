namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;

    using System;
    using System.IO;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            Mapper.Initialize(cfg => 
            {
                cfg.CreateMap<Supplier, ImportSupplierDTO>();
                cfg.AddProfile<CarDealerProfile>();
            });

            using (var db = new CarDealerContext())
            {
                var input = File.ReadAllText("./../../../Datasets/suppliers.xml");
                Console.WriteLine(ImportSuppliers(db, input));
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSupplierDTO[]), new XmlRootAttribute("Suppliers"));

            ImportSupplierDTO[] supplierDTOs;

            using (var reader = new StringReader(inputXml))
            {
                supplierDTOs = (ImportSupplierDTO[])xmlSerializer.Deserialize(reader);
            }

            var suppliers = Mapper.Map<Supplier[]>(supplierDTOs);

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }
    }
}