using System.Collections.Generic;

namespace P01_RawData
{
    public class Tire
    {
        public List<KeyValuePair<double, int>> tires = new List<KeyValuePair<double, int>>();
        public Tire(double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3age, double tire4Pressure, int tire4age)
        {
            tires.Add(new KeyValuePair<double, int>(tire1Pressure, tire1Age));
            tires.Add(new KeyValuePair<double, int>(tire2Pressure, tire2Age));
            tires.Add(new KeyValuePair<double, int>(tire3Pressure, tire3age));
            tires.Add(new KeyValuePair<double, int>(tire4Pressure, tire4age));
        }
    }
}
