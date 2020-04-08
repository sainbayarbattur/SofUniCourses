namespace PolymorphismExercise
{
    using System;
    using Vehicles;
    using VehiclesExtension;

    public class Program
    {
        public static void Main()
        {
            string carInput = Console.ReadLine();
            string truckInput = Console.ReadLine();
            string busInput = Console.ReadLine();

            //car

            string[] carToken = carInput.Split(' ');

            double fuelQuantity = double.Parse(carToken[1]);
            double fuelConsumption = double.Parse(carToken[2]);
            double tankCapacity = double.Parse(carToken[3]);

            var car = new Car(fuelQuantity, fuelConsumption, tankCapacity);

            //truck

            string[] truckToken = truckInput.Split(' ');

            fuelQuantity = double.Parse(truckToken[1]);
            fuelConsumption = double.Parse(truckToken[2]);
            tankCapacity = double.Parse(truckToken[3]);

            var truck = new Truck(fuelQuantity, fuelConsumption, tankCapacity);

            //bus

            string[] busToken = busInput.Split(' ');

            fuelQuantity = double.Parse(busToken[1]);
            fuelConsumption = double.Parse(busToken[2]);
            tankCapacity = double.Parse(busToken[3]);

            var bus = new Bus(fuelQuantity, fuelConsumption, tankCapacity);

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
                        else if (vehicle == "Truck")
                        {
                            truck.Drive(number);
                        }
                        else
                        {
                            bus.Drive(number);
                        }
                    }
                    else if (command == "Refuel")
                    {
                        if (vehicle == "Car")
                        {
                            car.Refuel(number);
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Refuel(number);
                        }
                        else
                        {
                            bus.Refuel(number);
                        }
                    }
                    else
                    {
                        if (vehicle == "Bus")
                        {
                            bus.DriveEmpty(number);
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
            Console.WriteLine(bus);
        }
    }
}