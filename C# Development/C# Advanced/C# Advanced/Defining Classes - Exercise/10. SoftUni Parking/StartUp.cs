using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new Car("Skoda", "Fabia", 65, "CC1856BG");
            var car2 = new Car("Audi", "A3", 110, "EB8787MN");
            var car3 = new Car("Audi1234", "A3", 110, "EB878*MN");

            var parking = new Parking(3);

            Console.WriteLine(parking.AddCar(car));
            Console.WriteLine(parking.AddCar(car2));
            Console.WriteLine(parking.AddCar(car3));

            parking.RemoveSetOfRegistrationNumber(new List<string> { "CC1856BG", "EB8787MN" });

            Console.WriteLine(parking.cars[2]);
        }
    }
}