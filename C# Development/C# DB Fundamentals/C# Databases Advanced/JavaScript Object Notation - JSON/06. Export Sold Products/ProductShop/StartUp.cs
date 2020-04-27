
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using System;
using System.IO;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using (var db = new ProductShopContext())
            {
                //db.Database.EnsureCreated();
                Console.WriteLine(GetSoldProducts(db));
            }
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var products = context.Users
                .Where(u => u.ProductsSold.Any() && u.ProductsSold.Any(ps => ps.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                .Select
                (
                    ps => new
                    {
                        name = ps.Name,
                        price = ps.Price,
                        buyerFirstName = ps.Buyer.FirstName,
                        buyerLastName = ps.Buyer.LastName,
                    }
                )
                .ToList()
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName)
                .ToList();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }
    }
}