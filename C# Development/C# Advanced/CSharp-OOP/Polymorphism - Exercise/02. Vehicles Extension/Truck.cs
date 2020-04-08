namespace Vehicles
{
    using System;
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + 1.6, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new Exception("Fuel must be a positive number");
            }

            if (this.FuelQuantity + liters > TanksCapacity)
            {
                throw new Exception($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters -= liters * 0.05;
        }
    }
}