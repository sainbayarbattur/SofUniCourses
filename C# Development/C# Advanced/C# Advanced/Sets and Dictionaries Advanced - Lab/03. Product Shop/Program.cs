namespace _03._Product_Shop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Product
    {
        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; private set; }

        public double Price { get; private set; }

        public override string ToString()
        {
            return $"Product: {this.Name}, Price: {this.Price}";
        }
    }

    public class Program
    {
        public static void Main()
        {
            var shops = new Dictionary<string, List<Product>>();

            string command = Console.ReadLine();

            while (command != "Revision")
            {
                string[] line = command.Split(", ");
                string shopName = line[0];

                if (!shops.ContainsKey(shopName))
                {
                    shops.Add(shopName, new List<Product>());
                }

                if (shops.ContainsKey(shopName))
                {
                    var product = new Product(line[1], double.Parse(line[2]));

                    shops[shopName].Add(product);
                }

                command = Console.ReadLine();
            }

            foreach (var shop in shops.OrderBy(s => s.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine(product);
                }
            }
        }
    }
}
