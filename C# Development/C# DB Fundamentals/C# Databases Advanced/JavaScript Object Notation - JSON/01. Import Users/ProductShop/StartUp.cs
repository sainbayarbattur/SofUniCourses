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
                var inputJason = File.ReadAllText("./../../../Datasets/users.json");

                Console.WriteLine(ImportUsers(db, inputJason));
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var result = new StringBuilder();

            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }
    }
}