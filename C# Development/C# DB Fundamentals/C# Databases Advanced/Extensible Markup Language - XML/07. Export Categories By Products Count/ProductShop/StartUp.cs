using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
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
                Console.WriteLine(GetCategoriesByProductsCount(db));
            }
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var products = context.Categories
                .Select(c => new ExportCategoriesByProductsCountDTO
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            using (var writer = new StringWriter())
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                var serializer = new XmlSerializer(typeof(ExportCategoriesByProductsCountDTO[]), new XmlRootAttribute("Categories"));
                serializer.Serialize(writer, products, ns);

                var productsXml = writer.GetStringBuilder();

                return productsXml.ToString().TrimEnd();
            }
        }
    }
}