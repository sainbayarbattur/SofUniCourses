namespace NeedForSpeed.Vehicles
{
    public class Car : Vehicle
    {
        const int carDefaultFuelConsumption = 3;

        public Car(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => carDefaultFuelConsumption;
    }
}
