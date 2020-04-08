namespace WildFarm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        public virtual List<Food> Foods { get; set; }

        public virtual void Eat(string typeOfFood, int quantity)
        {
            if (!Foods.Any(x => x.TypeOfFood == typeOfFood))
            {
                throw new Exception($"{this.GetType().Name} does not eat {typeOfFood}!");
            }

            FoodEaten += quantity;
        }

        public virtual string ProduceSound()
        {
            throw new System.NotImplementedException();
        }
    }
}