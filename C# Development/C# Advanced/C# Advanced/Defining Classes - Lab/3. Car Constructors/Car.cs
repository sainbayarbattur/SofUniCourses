namespace _1._Car
{
    using System;
    using System.Text;

    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsuption)
            : this(make, model, year)
        {
            this.FuelConsumption = fuelConsuption;
            this.FuelQuantity = fuelQuantity;
        }

        public void Drive(double distance)
        {
            if (this.FuelQuantity - ((distance / 100) * this.FuelConsumption) > 0)
            {
                this.FuelQuantity -= ((distance / 100) * this.FuelConsumption);
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            var result = new StringBuilder();

            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Year: {this.Year}");
            result.Append($"Fuel: {this.FuelQuantity:F2}L");

            return result.ToString();
        }

        public string Make { get => make; set { make = value; } }

        public string Model { get => model; set { model = value; } }

        public int Year { get => year; set { year = value; } }

        public double FuelQuantity { get => fuelQuantity; set { fuelQuantity = value; } }

        public double FuelConsumption { get => fuelConsumption; set { fuelConsumption = value; } }
    }
}