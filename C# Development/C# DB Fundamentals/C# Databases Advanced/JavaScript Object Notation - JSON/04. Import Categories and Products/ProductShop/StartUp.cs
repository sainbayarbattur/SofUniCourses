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
                var inputJason = File.ReadAllText("./../../../Datasets/categories-products.json");

                Console.WriteLine(ImportCategoryProducts(db, inputJason));
            }
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var result = new StringBuilder();

            var categories = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }
    }
}