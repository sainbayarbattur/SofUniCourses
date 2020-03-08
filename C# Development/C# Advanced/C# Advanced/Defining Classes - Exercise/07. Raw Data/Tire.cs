namespace Problem_8._Raw_Data
{
    public class Tire
    {
        public Tire(int firstAge, double firstPressure)
        {
            TirePressure = firstPressure;
            TireAge = firstAge;
        }

        public double TirePressure { get; set; }

        public int TireAge { get; set; }
    }
}
