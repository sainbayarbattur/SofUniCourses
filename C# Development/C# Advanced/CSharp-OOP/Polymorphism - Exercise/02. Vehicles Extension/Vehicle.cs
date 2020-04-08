namespace Vehicles
{
    using System;
    public abstract class Vehicle
    {
        private double tanksCapacity;
        private double fuelConsumption;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                fuelQuantity = 0;
            }
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TanksCapacity = tankCapacity;
        }

        public double TanksCapacity { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public void Drive(double km)
        {
            string vehicle = this.GetType().Name;

            if (this.FuelQuantity - (this.FuelConsumption * km) <= 0)
            {
                throw new Exception($"{vehicle} needs refueling");
            }
            this.FuelQuantity -= this.FuelConsumption * km;

            throw new Exception($"{vehicle} travelled {km} km");
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new Exception("Fuel must be a positive number");
            }

            if (this.FuelQuantity + liters > TanksCapacity)
            {
                throw new Exception($"Cannot fit {liters} fuel in the tank");
            }
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}