using System.Collections.Generic;

namespace P01_RawData
{
    public class Car
    {
        public string model;
        public Engine Engine { get; set; }
        public Tire Tire { get; set; }
        public Cargo Cargo { get; set; }
        public List<KeyValuePair<double, int>> tires = new List<KeyValuePair<double, int>>();

        public Car(string model, Engine engine, Cargo cargo, Tire tire)
        {
            this.model = model;
            Engine = engine;
            Tire = tire;
            Cargo = cargo;
        }
    }
}
