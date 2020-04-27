namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;

    using System;
    using System.IO;
    using System.Linq;
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
                //db.Database.EnsureCreated();

                var input = File.ReadAllText("./../../../Datasets/parts.xml");
                Console.WriteLine(ImportParts(db, input));
            }
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPartDTO[]), new XmlRootAttribute("Parts"));

            ImportPartDTO[] supplierDTOs;

            using (var reader = new StringReader(inputXml))
            {
                supplierDTOs = ((ImportPartDTO[])xmlSerializer.Deserialize(reader))
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToArray();
            }

            var parts = Mapper.Map<Part[]>(supplierDTOs);

            context.Parts.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }
    }
}