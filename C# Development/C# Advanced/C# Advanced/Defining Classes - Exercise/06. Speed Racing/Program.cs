namespace Problem_7._Speed_Racing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var result = new List<Car>();

            var car = new Car();

            for (int i = 0; i < n; i++)
            {
                string[] currInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string model = currInput[0];

                int amount = int.Parse(currInput[1]);

                double consumption = double.Parse(currInput[2]);

                var currCar = new Car()
                {
                    Model = model,
                    Amount = amount,
                    Consumtion = consumption
                };
                result.Add(currCar);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End") break;

                string[] token = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string model = token[1];

                int kmToRide = int.Parse(token[2]);

                result.Find(x => x.Model == model).Calculate(kmToRide);
            }

            foreach (var _car in result)
            {
                Console.WriteLine($"{_car.Model} {_car.Amount:f2} {_car.Distance}");
            }
        }
    }
}
