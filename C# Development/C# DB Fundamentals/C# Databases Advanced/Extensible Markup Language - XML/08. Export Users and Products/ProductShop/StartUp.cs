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
                Console.WriteLine(GetUsersWithProducts(db));
            }
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(p => p.ProductsSold.Count())
                .Select(u => new UserDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductsDTO
                    {
                        Count = u.ProductsSold.Count(),
                        Products = u.ProductsSold
                            .Select(p => new ProductDTO
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            var userAndProducts = new ExportUsersAndProducts
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = users
            };

            using (var writer = new StringWriter())
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                var serializer = new XmlSerializer(typeof(ExportUsersAndProducts), new XmlRootAttribute("Users"));
                serializer.Serialize(writer, userAndProducts, ns);

                var userAndProductsXml = writer.GetStringBuilder();

                return userAndProductsXml.ToString().TrimEnd();
            }
        }
    }
}