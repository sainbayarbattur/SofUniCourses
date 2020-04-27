using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using (var db = new ProductShopContext())
            {
                var inputJason = File.ReadAllText("./../../../Datasets/products.json");

                Console.WriteLine(ImportProducts(db, inputJason));
            }
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var result = new StringBuilder();

            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
    }
}