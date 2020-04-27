using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ImportProductDTO>();
                cfg.AddProfile<ProductShopProfile>();
            });

            using (var db = new ProductShopContext())
            {
                //db.Database.EnsureCreated();

                var input = File.ReadAllText("./../../../Datasets/products.xml");

                Console.WriteLine(ImportProducts(db, input));
            }
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProductDTO[]), new XmlRootAttribute("Products"));

            var productsDtos = Mapper.Map<ImportProductDTO[]>(xmlSerializer);

            using (var reader = new StringReader(inputXml))
            {
                productsDtos = (ImportProductDTO[])xmlSerializer.Deserialize(reader);
            }

            var products = Mapper.Map<Product[]>(productsDtos);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
    }
}