namespace Problem_8._Raw_Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string currInput = Console.ReadLine();

                string[] token = currInput.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string model = token[0];
                int engineSpeed = int.Parse(token[1]);
                int enginePower = int.Parse(token[2]);
                int cargoWeight = int.Parse(token[3]);
                string cargoType = token[4];
                double Tire1Pressure = double.Parse(token[5]);
                int Tire1Age = int.Parse(token[6]);
                double Tire2Pressure = double.Parse(token[7]);
                int Tire2Age = int.Parse(token[8]);
                double Tire3Pressure = double.Parse(token[9]);
                int Tire3Age = int.Parse(token[10]);
                double Tire4Pressure = double.Parse(token[11]);
                int Tire4Age = int.Parse(token[12]);

                var engine = new Engine(engineSpeed, enginePower);

                var cargo = new Cargo(cargoWeight, cargoType);

                var firstTire = new Tire(Tire1Age, Tire1Pressure);

                var secondTire = new Tire(Tire2Age, Tire2Pressure);

                var thirdTire = new Tire(Tire3Age, Tire3Pressure);

                var fourthTire = new Tire(Tire4Age, Tire4Pressure);

                var tires = new Tire[]
                {
                    firstTire,
                    secondTire,
                    thirdTire,
                    fourthTire
                };

                var car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars.Where(x => x.Cargo.Type == "fragile"
                                && x.Tires.Any(y => y.TirePressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else
            {
                foreach (var car in cars.Where(x => x.Cargo.Type == "flamable"
                                && x.Engine.EnginePower > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
