namespace Problem_10._Car_Salesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var car = new List<Car>();

            var engine = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] currInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = currInput[0];

                string power = currInput[1];

                string displacement = "n/a";

                string efficiency = "n/a";

                if (currInput.Length >= 3)
                {
                    if (!int.TryParse(currInput[2], out int a))
                    {
                        efficiency = currInput[2];
                    }
                    else
                    {
                        displacement = currInput[2];
                    }
                }

                if (currInput.Length >= 4)
                {
                    if (int.TryParse(currInput[3], out int a))
                    {
                        displacement = currInput[3];
                    }
                    else
                    {
                        efficiency = currInput[3];
                    }
                }

                var newEngine = new Engine()
                {
                    Model = name,
                    Power = power,
                    Displacement = displacement,
                    Efficiency = efficiency
                };

                engine.Add(newEngine);
            }

            int secodnN = int.Parse(Console.ReadLine());

            for (int i = 0; i < secodnN; i++)
            {
                string[] currInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string carName = currInput[0];

                string engineName = currInput[1];

                string weight = "n/a";

                string color = "n/a";

                if (currInput.Length >= 3)
                {
                    if (!int.TryParse(currInput[2], out int a))
                    {
                        color = currInput[2];
                    }
                    else
                    {
                        weight = currInput[2];
                    }
                }

                if (currInput.Length >= 4)
                {
                    if (int.TryParse(currInput[3], out int a))
                    {
                        weight = currInput[3];
                        continue;
                    }
                    else
                    {
                        color = currInput[3];
                    }
                }

                var newCar = new Car()
                {
                    Model = carName,
                    Color = color,
                    Engine = engineName,
                    Weight = weight
                };

                car.Add(newCar);
            }

            foreach (var _car in car)
            {
                foreach (var _engine in engine.Where(x => x.Model == _car.Engine))
                {
                    string currRe =
                                $"{_car.Model}:\n" +
                                $"  {_car.Engine}:\n" +
                                $"    Power: {_engine.Power}\n" +
                                $"    Displacement: {_engine.Displacement}\n" +
                                $"    Efficiency: {_engine.Efficiency}\n" +
                                $"  Weight: {_car.Weight}\n" +
                                $"  Color: {_car.Color}\n";

                    Console.Write(currRe);
                }
            }
        }
    }
}