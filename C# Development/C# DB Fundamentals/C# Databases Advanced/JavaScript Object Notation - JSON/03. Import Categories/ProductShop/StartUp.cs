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
                var inputJason = File.ReadAllText("./../../../Datasets/categories.json");

                Console.WriteLine(ImportCategories(db, inputJason));
            }
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var result = new StringBuilder();

            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson).Where(c => c.Name != null).ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }
    }
}