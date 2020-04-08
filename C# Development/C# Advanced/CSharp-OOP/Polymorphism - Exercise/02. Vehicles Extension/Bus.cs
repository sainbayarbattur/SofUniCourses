namespace VehiclesExtension
{
    using System;
    using Vehicles;
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + 1.4, tankCapacity)
        {
        }

        public void DriveEmpty(double km)
        {
            FuelConsumption -= 1.4;

            if (this.FuelQuantity - (this.FuelConsumption * km) <= 0)
            {
                throw new Exception($"Bus needs refueling");
            }
            this.FuelQuantity -= this.FuelConsumption * km;

            throw new Exception($"Bus travelled {km} km");
        }
    }
}