using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Pizza
    {
        private readonly string name;

        public Pizza(string name)
        {
            toppings = new List<Topping>();
            this.name = name;
        }

        public double AllCalories { get; set; }

        private List<Topping> toppings;

        public void Toppings(Topping topping)
        {
            if (toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }
    }
}
