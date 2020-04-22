namespace SoftUniParking
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Parking
    {
        public Car[] cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.cars = new Car[capacity];
            this.capacity = capacity;
        }

        public int Count => cars.Where(c => c != null).Count();

        public string AddCar(Car car)
        {
            if (this.cars.Any(c => c != null && c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (this.Count + 1 > this.capacity)
            {
                return "Parking is full!";
            }

            this.cars[this.Count] = car;

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            Car carToRemove = this.cars.FirstOrDefault(c => c != null && c.RegistrationNumber == registrationNumber);

            if (!this.cars.Any(c => c != null && c.RegistrationNumber == registrationNumber) || carToRemove == null)
            {
                return "Car with that registration number, doesn't exist!";
            }

            var index = Array.IndexOf(this.cars, carToRemove);

            this.cars[index] = null;

            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            return this.cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            for (int i = 0; i < registrationNumbers.Count; i++)
            {
                string currentRegistrationNumber = registrationNumbers[i];

                if (this.cars.Any(c => c != null && c.RegistrationNumber == currentRegistrationNumber))
                {
                    Car carToRemove = this.cars[i];

                    if (carToRemove != null)
                    {
                        var index = Array.IndexOf(this.cars, carToRemove);

                        this.cars[index] = null;
                    }
                }
            }
        }
    }
}