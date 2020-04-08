namespace WildFarm.Animals.Mammals.Felines
{
    using System.Collections.Generic;
    using WildFarm.Foods;
    public class Tiger : Feline
    {
        private const double WEIGHT_PLUS = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
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
            return "ROAR!!!";
        }

        public override string ToString()
        {
            return $"Tiger [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}