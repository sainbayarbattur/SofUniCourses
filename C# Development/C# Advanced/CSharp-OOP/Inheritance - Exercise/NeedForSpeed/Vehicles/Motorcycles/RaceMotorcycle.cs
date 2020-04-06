namespace NeedForSpeed.Vehicles.Motorcycles
{
    public class RaceMotorcycle : Motorcycle
    {
        const int raceMotorcycleDefaultFuelConsumption = 8;

        public RaceMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => raceMotorcycleDefaultFuelConsumption;
    }
}
