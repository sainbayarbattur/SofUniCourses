namespace VehicleCatalogue
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public class Vechicles
        {
            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public double HorsePower { get; set; }

            public Vechicles(string type, string model, string color, double horsePower)
            {
                Type = type;
                Model = model;
                Color = color;
                HorsePower = horsePower;
            }
        }

        public static void Main()
        {
            var result = new List<Vechicles>();
            string type = string.Empty;
            string model = string.Empty;
            string color = string.Empty;
            double horsePower = 0;

            while (true)
            {
                List<string> input = Console.ReadLine().Split().ToList();
                if (input[0] == "End")
                {
                    break;
                }
                type = input[0];
                model = input[1];
                color = input[2];
                string firstType = type.Substring(0, 1).ToUpper();
                firstType += type.Substring(1);
                horsePower = double.Parse(input[3]);
                
                var cars = new Vechicles(firstType, model, color, horsePower);
                result.Add(cars);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Close the Catalogue")
                {
                    break;
                }

                foreach (var item in result)
                {
                    if (item.Model.Contains(input))
                    {
                        Console.WriteLine($"Type: {item.Type}");
                        Console.WriteLine($"Model: {item.Model}");
                        Console.WriteLine($"Color: {item.Color}");
                        Console.WriteLine($"Horsepower: {item.HorsePower}");
                    }
                }
            }

            double sumTruck = 0;
            double sumCar = 0;

            foreach (var item in result)
            {
                if (item.Type == "Car")
                {
                    sumCar += item.HorsePower;
                }
                else
                {
                    sumTruck += item.HorsePower;
                }
            }
            int countCar = result.Where(x => x.Type == "Car").Count();
            int countCTruck = result.Where(x => x.Type == "Truck").Count();
            if (sumCar > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {sumCar/countCar:f2}.");
            }
            else if(sumCar == 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }
            if (sumTruck > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {sumTruck/countCTruck:f2}.");
            }
            else if(sumTruck == 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
    }
}
