namespace _1._Car
{
    using System;
    using System.Text;
    using CarManufacturer;

    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

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

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsuption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsuption)
        {
            this.Engine = engine;
            this.Tires = tires;
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

        public Engine Engine { get => this.engine; set { this.engine = value; } }

        public Tire[] Tires { get => this.tires; set { this.tires = value; } }

        public string Make { get => this.make; set { this.make = value; } }

        public string Model { get => this.model; set { this.model = value; } }

        public int Year { get => this.year; set { this.year = value; } }

        public double FuelQuantity { get => this.fuelQuantity; set { this.fuelQuantity = value; } }

        public double FuelConsumption { get => this.fuelConsumption; set { this.fuelConsumption = value; } }
    }
}