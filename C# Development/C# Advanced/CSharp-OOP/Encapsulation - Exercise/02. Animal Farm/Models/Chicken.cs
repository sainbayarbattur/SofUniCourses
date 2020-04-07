namespace AnimalFarm.Models
{
    using System;
    public class Chicken
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;

        private string name;
        private int age;

        internal Chicken(string name, int age)
        {
            if (!ValidateChikensName(name))
            {
                throw new Exception("Name cannot be empty.");
            }
            else if (!ValidateChikensAge(age))
            {
                throw new Exception("Age should be between 0 and 15.");
            }

            this.name = name;
            this.age = age;
        }

        public string Name { get => name; }

        public int Age { get => age; }

        public double ProductPerDay { get => CalculateProductPerDay(); }

        private double CalculateProductPerDay()
        {
            switch (this.Age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }

        private bool ValidateChikensName(string name)
        {
            if (name == null || name == string.Empty || name == " ")
            {
                return false;
            }
            return true;
        }

        private bool ValidateChikensAge(int age)
        {
            if (age < 0 || age > 15)
            {
                return false;
            }
            return true;
        }
    }
}
