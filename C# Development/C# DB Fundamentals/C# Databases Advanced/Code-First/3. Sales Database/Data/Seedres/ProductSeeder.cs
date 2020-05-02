namespace P03_SalesDatabase.Data.Seedres
{
    using P03_SalesDatabase.Data.Models;
    using System;
    using System.Text;

    public class ProductSeeder : Seeder
    {
        public override void Seed(SalesContext db)
        {
            var rand = new Random();

            var name = RandomString(rand.Next(7, 40), Convert.ToBoolean(rand.Next(0, 1)));

            var qunantity = rand.Next(0, 20);

            var price = rand.Next(0, 20);

            db.Add(new Product 
            {
                Name = name,
                Price = price,
                Quantity = qunantity
            });
        }
    }
}