using Restaurant.Foods;

namespace Restaurant.Beverages.HotBeverages
{
    public class Soup : Starter
    {
        public Soup(string name, decimal price, double grams)
            : base(name, price, grams)
        {
        }
    }
}