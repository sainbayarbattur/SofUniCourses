namespace _6._Parking_Lot
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            var parking = new HashSet<string>();

            while (line != "END")
            {
                string direction = line.Split(", ")[0];
                string carNumber = line.Split(", ")[1];

                if (direction == "OUT")
                {
                    parking.Remove(carNumber);
                }
                else if (direction == "IN")
                {
                    parking.Add(carNumber);
                }

                line = Console.ReadLine();
            }

            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                Console.WriteLine(string.Join('\n', parking));
            }
        }
    }
}