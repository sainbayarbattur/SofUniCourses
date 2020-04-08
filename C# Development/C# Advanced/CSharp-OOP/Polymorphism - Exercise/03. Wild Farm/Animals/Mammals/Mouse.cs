using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double WEIGHT_PLUS = 0.10;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override List<Food> Foods { get => new List<Food> { new Vegetable(), new Fruit() }; }

        public override void Eat(string typeOfFood, int quantity)
        {
            base.Eat(typeOfFood, quantity);
            Weight += WEIGHT_PLUS * quantity;
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"Mouse [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}