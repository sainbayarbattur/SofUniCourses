namespace Vehicles
{
    using System;
    public abstract class Vehicle
    {
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
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}