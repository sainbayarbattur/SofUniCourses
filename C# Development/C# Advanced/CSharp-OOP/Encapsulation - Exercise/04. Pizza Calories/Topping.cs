namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    public class Topping
    {
        private double wight;
        private string type;
        private const int baseCalories = 2;
        private Dictionary<string, double> types;
        private void AddTypes()
        {
            types.Add("meat", 1.2);
            types.Add("veggies", 0.8);
            types.Add("cheese", 1.1);
            types.Add("sauce", 0.9);
        }
        private double calories;
        private readonly string oldType;

        public Topping(string type, double wight)
        {
            types = new Dictionary<string, double>();
            AddTypes();
            oldType = type;
            this.Type = type.ToLower();
            this.Wight = wight;
        }

        public void CalculateCalories()
        {
            calories = baseCalories * (Wight * types[Type]);
        }

        public double Calories { get => calories; private set => calories = value; }

        public string Type
        {
            get { return type; }
            set
            {
                if (!types.ContainsKey(value))
                {
                    throw new ArgumentException($"Cannot place {oldType} on top of your pizza.");
                }
                type = value;
            }
        }

        public double Wight
        {
            get { return wight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{oldType} weight should be in the range [1..50].");
                }
                wight = value;
            }
        }
    }
}