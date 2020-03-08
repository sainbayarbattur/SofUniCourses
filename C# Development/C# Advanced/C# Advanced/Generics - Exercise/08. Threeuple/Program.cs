namespace _08._Threeuple
{
    using System;
    using _08_Threeuple;

    public class Program
    {
        public static void Main()
        {
            string[] line1 = Console.ReadLine().Split();
            string fullName = line1[0] + " " + line1[1];
            string address = line1[2];
            string town = line1[3];

            var first = new Threeuple<string, string, string>(fullName, address, town);

            string[] line2 = Console.ReadLine().Split();
            string name = line2[0];
            int beer = int.Parse(line2[1]);
            bool drunk = false;
            if (line2[2] == "drunk") drunk = true;
            
            var second = new Threeuple<string, int, bool>(name, beer, drunk);

            string[] line3 = Console.ReadLine().Split();
            string secondName = line3[0];
            double doubleNumber = double.Parse(line3[1]);
            string bankName = line3[2];

            var third = new Threeuple<string, double, string>(secondName, doubleNumber, bankName);

            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
        }
    }
}