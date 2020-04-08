namespace PolymorphismExercise
{
    using System;
    using Vehicles;

    public class Program
    {
        public static void Main()
        {
            string carInput = Console.ReadLine();
            string truckInput = Console.ReadLine();

            string[] carToken = carInput.Split(' ');

            double fuelQuantity = double.Parse(carToken[1]);
            double fuelConsumption = double.Parse(carToken[2]);

            var car = new Car(fuelQuantity, fuelConsumption);

            string[] truckToken = truckInput.Split(' ');

            fuelQuantity = double.Parse(truckToken[1]);
            fuelConsumption = double.Parse(truckToken[2]);

            var truck = new Truck(fuelQuantity, fuelConsumption);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string commands = Console.ReadLine();

                string[] token = commands.Split(' ');

                string command = token[0];
                string vehicle = token[1];
                double number = double.Parse(token[2]);

                try
                {
                    if (command == "Drive")
                    {
                        if (vehicle == "Car")
                        {
                            car.Drive(number);
                        }
                        else
                        {
                            truck.Drive(number);
                        }
                    }
                    else
                    {
                        if (vehicle == "Car")
                        {
                            car.Refuel(number);
                        }
                        else
                        {
                            truck.Refuel(number);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}