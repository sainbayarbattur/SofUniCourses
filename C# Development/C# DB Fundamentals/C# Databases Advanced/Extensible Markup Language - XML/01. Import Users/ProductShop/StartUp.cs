using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.IO;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using (var db = new ProductShopContext())
            {
                var input = File.ReadAllText("./../../../Datasets/users.xml");

                ImportUsers(db, input);
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(User[]), new XmlRootAttribute("Users"));

            var users = (User[])xmlSerializer.Deserialize(new StringReader(inputXml));

            context.Users.AddRange(users);

            return $"Successfully imported {users.Length}";
        }
    }
}