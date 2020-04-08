namespace WildFarm.Animals.Mammals
{
    using System.Collections.Generic;
    using WildFarm.Foods;
    public class Dog : Mammal
    {
        private const double WEIGHT_PLUS = 0.40;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
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
            return "Woof!";
        }

        public override string ToString()
        {
            return $"Dog [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}