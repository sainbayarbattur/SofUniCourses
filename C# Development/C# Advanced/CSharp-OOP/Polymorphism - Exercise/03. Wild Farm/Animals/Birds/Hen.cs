namespace WildFarm.Animals.Birds
{
    using System.Collections.Generic;
    using WildFarm.Foods;
    public class Hen : Bird
    {
        private const double WEIGHT_PLUS = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override List<Food> Foods { get => new List<Food> { new Meat(), new Seeds(), new Vegetable(), new Fruit() }; }

        public override void Eat(string typeOfFood, int quantity)
        {
            base.Eat(typeOfFood, quantity);
            Weight += WEIGHT_PLUS * quantity;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override string ToString()
        {
            return $"Hen [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}