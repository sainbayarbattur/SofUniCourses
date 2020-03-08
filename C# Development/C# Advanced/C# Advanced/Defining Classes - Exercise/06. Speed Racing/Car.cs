using System;

namespace Problem_7._Speed_Racing
{
    public class Car
    {
        private string model;
        private double amount;
        private double consumtion;
        private double distance;

        public double Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        public double Consumtion
        {
            get { return consumtion; }
            set { consumtion = value; }
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public void Calculate(double distance)
        {
            double amountNeeded = distance * consumtion;

            if (Amount >= amountNeeded)
            {
                Amount -= amountNeeded;
                Distance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
