namespace WildFarm.Animals.Birds
{
    using System.Collections.Generic;
    using WildFarm.Foods;

    public class Owl : Bird
    {
        private const double WEIGHT_PLUS = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override List<Food> Foods { get => new List<Food> { new Meat() }; }

        public override void Eat(string typeOfFood, int quantity)
        {
            base.Eat(typeOfFood, quantity);
            Weight += WEIGHT_PLUS * quantity;
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override string ToString()
        {
            return $"Owl [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}