namespace _4HotelReservation
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ');

            decimal pricePerDay = decimal.Parse(input[0]);
            int numberOfDays = int.Parse(input[1]);
            string season = input[2];

            string typeClient = string.Empty;

            if (input.Length == 4)
            {
                typeClient = input[3];
            }

            Console.WriteLine(PriceCalculator.GetTotalPrice(pricePerDay, numberOfDays, season, typeClient).ToString("f2"));

        }
    }
}