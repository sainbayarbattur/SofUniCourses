namespace P03_SalesDatabase.Data.Seedres
{
    using P03_SalesDatabase.Data.Models;
    using System;
    using System.Linq;

    public class SaleSeeder : Seeder
    {
        public override void Seed(SalesContext db)
        {
            var rand = new Random();

            var date = RandomDay(rand);

            db.Sales.Add(new Sale
            {
                Date = date,
                Customer = db.Customers.Find(1),
                Product = db.Products.Find(1),
                Store = db.Stores.Find(1),
            });
        }

        DateTime RandomDay(Random gen)
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}