namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Dough
    {
        private const int baseCalories = 2; 
        private Dictionary<string, double> flourType;
        private Dictionary<string, double> bakingTechnique;
        private void AddValuePairs()
        {
            flourType.Add("white", 1.5);
            flourType.Add("wholegrain", 1.0);
            bakingTechnique.Add("crispy", 0.9);
            bakingTechnique.Add("chewy", 1.1);
            bakingTechnique.Add("homemade", 1.0);
        }
        private double weight;
        private string flourTypeInput;
        private string bakingTechniqueInput;
        private double calories;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.flourType = new Dictionary<string, double>();
            this.bakingTechnique = new Dictionary<string, double>();
            AddValuePairs();
            Weight = weight;
            FlourTypeInput = flourType.ToLower();
            BakingTechniqueInput = bakingTechnique.ToLower();
        }

        public string BakingTechniqueInput
        {
            get => bakingTechniqueInput;
            set
            {
                if (!bakingTechnique.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechniqueInput = value;
            }
        }

        public string FlourTypeInput
        {
            get => flourTypeInput;
            set
            {
                if (!flourType.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourTypeInput = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public void ClaculateCalories()
        {
            calories = (baseCalories * weight) * flourType[flourTypeInput] * bakingTechnique[bakingTechniqueInput];
        }

        public double Calories { get => calories; private set => calories = value; }
    }
}