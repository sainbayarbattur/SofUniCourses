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
                cfg.AddProfile<ProductShopProfile>();
            });

            using (var db = new ProductShopContext())
            {
                db.Database.EnsureCreated();

                var input = File.ReadAllText("./../../../Datasets/categories.xml");

                Console.WriteLine(ImportCategories(db, input));
            }
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryDTO[]), new XmlRootAttribute("Categories"));

            var categoriesDtos = Mapper.Map<ImportCategoryDTO[]>(xmlSerializer);

            using (var reader = new StringReader(inputXml))
            {
                categoriesDtos = ((ImportCategoryDTO[])xmlSerializer.Deserialize(reader))
                    .Where(c => c.Name != null)
                    .ToArray();
            }

            var products = Mapper.Map<Category[]>(categoriesDtos);

            context.Categories.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
    }
}