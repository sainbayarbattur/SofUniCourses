namespace P03_SalesDatabase.Data.Seedres
{
    using P03_SalesDatabase.Data.Models;
    using System;
    using System.Text;

    public class StoreSeeder : Seeder
    {
        public override void Seed(SalesContext db)
        {
            var rand = new Random();

            var name = RandomString(rand.Next(7, 40), Convert.ToBoolean(rand.Next(0, 1)));

            db.Stores.Add(new Store
            {
                Name = name
            });
        }
    }
}