namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            fuelConsumption += 0.9;
            this.FuelConsumption = fuelConsumption;
        }
    }
}