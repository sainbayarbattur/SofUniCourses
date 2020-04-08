namespace WildFarm.Animals.Mammals.Felines
{
    using System.Collections.Generic;
    using WildFarm.Foods;
    public class Cat : Feline
    {
        private const double WEIGHT_PLUS = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override List<Food> Foods { get => new List<Food> { new Vegetable(), new Meat() }; }

        public override void Eat(string typeOfFood, int quantity)
        {
            base.Eat(typeOfFood, quantity);
            Weight += WEIGHT_PLUS * quantity;
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override string ToString()
        {
            return $"Cat [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}