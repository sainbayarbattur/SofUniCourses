namespace NeedForSpeed.Vehicles.Cars
{
    public class SportCar : Car
    {
        const int sportCarDefaultFuelConsumption = 10;

        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => sportCarDefaultFuelConsumption;
    }
}
