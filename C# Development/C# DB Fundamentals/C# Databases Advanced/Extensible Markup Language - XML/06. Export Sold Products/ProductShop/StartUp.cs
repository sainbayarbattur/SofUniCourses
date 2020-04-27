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
                Console.WriteLine(GetSoldProducts(db));
            }
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var products = context.Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportSoldProductsDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Product = u.ProductsSold.Select(ps => new ProductDTO
                    {
                        Name = ps.Name,
                        Price = ps.Price
                    })
                    .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            using (var writer = new StringWriter())
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                var serializer = new XmlSerializer(typeof(ExportSoldProductsDTO[]), new XmlRootAttribute("Users"));
                serializer.Serialize(writer, products, ns);

                var productsXml = writer.GetStringBuilder();

                return productsXml.ToString().TrimEnd();
            }
        }
    }
}