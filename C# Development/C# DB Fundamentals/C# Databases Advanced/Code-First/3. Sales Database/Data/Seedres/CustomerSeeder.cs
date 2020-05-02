namespace P03_SalesDatabase.Data.Seedres
{
    using P03_SalesDatabase.Data.Models;
    using System;

    class CustomerSeeder : Seeder
    {
        public override void Seed(SalesContext db)
        {
            var rand = new Random();

            var name = RandomString(rand.Next(7, 40), Convert.ToBoolean(rand.Next(0, 1)));

            var email = RandomString(rand.Next(7, 40), Convert.ToBoolean(rand.Next(0, 1)));

            var creditCardNumber = RandomString(rand.Next(7, 40), Convert.ToBoolean(rand.Next(0, 1)));

            db.Add(new Customer
            {
                Name = name,
                Email = email,
                CreditCardNumber = creditCardNumber
            });
        }
    }
}