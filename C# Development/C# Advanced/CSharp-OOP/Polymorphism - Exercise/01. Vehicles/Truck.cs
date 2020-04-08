namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            fuelConsumption += 1.6;
            this.FuelConsumption = fuelConsumption;
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters -= liters * 0.05;
        }
    }
}