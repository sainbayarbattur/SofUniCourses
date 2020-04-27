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
                Console.WriteLine(GetProductsInRange(db));
            }
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Select(p => new ExportProductsInRangeDTO { Price = p.Price, Name = p.Name, Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}" })
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            using (var writer = new StringWriter())
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                var serializer = new XmlSerializer(typeof(ExportProductsInRangeDTO[]), new XmlRootAttribute("Products"));
                serializer.Serialize(writer, products, ns);

                var productsXml = writer.GetStringBuilder();

                return productsXml.ToString().TrimEnd();
            }
        }
    }
}