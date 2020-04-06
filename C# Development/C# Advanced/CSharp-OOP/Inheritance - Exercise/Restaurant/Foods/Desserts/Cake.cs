namespace Restaurant.Foods.Desserts
{
    public class Cake : Dessert
    {
        private const int defaultCakeGrams = 250;
        private const int defaultCakeCalories = 1000;
        private const int defaultCakeCakePrice = 5;

        public Cake(string name)
            : base(name, defaultCakeCakePrice, defaultCakeGrams, defaultCakeCalories)
        {
        }

        public override double Grams => defaultCakeGrams;

        public override double Calories => defaultCakeCalories;

        public override decimal Price => defaultCakeCakePrice;
    }
}
