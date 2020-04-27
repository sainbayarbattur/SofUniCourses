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

                var input = File.ReadAllText("./../../../Datasets/categories-products.xml");

                Console.WriteLine(ImportCategoryProducts(db, input));
            }
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDTO[]), new XmlRootAttribute("CategoryProducts"));

            var categoryProductsDtos = Mapper.Map<ImportCategoryProductDTO[]>(xmlSerializer);

            using (var reader = new StringReader(inputXml))
            {
                categoryProductsDtos = ((ImportCategoryProductDTO[])xmlSerializer.Deserialize(reader))
                    .Where(cp => context.Categories.Any(c => cp.CategoryId == c.Id) && context.Products.Any(p => p.Id == cp.ProductId))
                    .ToArray();
            }

            var categoryProducts = Mapper.Map<CategoryProduct[]>(categoryProductsDtos);

            context.CategoryProducts.AddRange(categoryProducts);

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }
    }
}