namespace CarManufacturer
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string command = Console.ReadLine();

            var tiresList = new List<Tire[]>();
            var enginesList = new List<Engine>();
            var carsList = new List<Car>();

            while (command != "No more tires")
            {
                string[] tires = command.Split(' ');

                var tirePair = new List<Tire>();
                int count = 1;

                while (tirePair.Count != 4)
                {
                    int year = int.Parse(tires[count - 1]);
                    double pressure = double.Parse(tires[count]);

                    tirePair.Add(new Tire(year, pressure));

                    count += 2;
                }

                tiresList.Add(tirePair.ToArray());

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "Engines done")
            {
                int horsePower = int.Parse(command.Split(' ')[0]);
                double cubicCapacity = double.Parse(command.Split(' ')[1]);

                enginesList.Add(new Engine(horsePower, cubicCapacity));

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "Show special")
            {
                string make = command.Split(' ')[0];
                string model = command.Split(' ')[1];
                int year = int.Parse(command.Split(' ')[2]);
                double fuelQuantity = double.Parse(command.Split(' ')[3]);
                double fuelConsumption = int.Parse(command.Split(' ')[4]);
                int engineIndex = int.Parse(command.Split(' ')[5]);
                int tiresIndex = int.Parse(command.Split(' ')[6]);
                Engine engine = enginesList[engineIndex];
                Tire[] tires = tiresList[tiresIndex];

                carsList.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires));

                command = Console.ReadLine();
            }

            var specialCars = carsList
                .Where(c => c.Year >= 2017
                && c.Engine.HorsePower > 330
                && c.Tires.Sum(t => t.Pressure) >= 9
                && c.Tires.Sum(t => t.Pressure) <= 10)
                .ToList();

            foreach (var car in specialCars)
            {
                car.Drive(20);

                Console.WriteLine(car);
            }
        }
    }
}