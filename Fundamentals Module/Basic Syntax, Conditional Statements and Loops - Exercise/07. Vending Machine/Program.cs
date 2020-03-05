using System;

namespace ConsoleApp61
{
    class Program
    {
        static void Main(string[] args)
        {
            string Start = Console.ReadLine().ToLower();
            decimal allcoins = 0;
            decimal Change = 0;
            decimal Nuts = 2.0m;
            decimal Water = 0.7m;
            decimal Crisps = 1.5m;
            decimal Soda = 0.8m;
            decimal Coke = 1.0m;

            while (Start != "Start")
            {
                decimal numCoins = decimal.Parse(Start);
                if (numCoins == 0.1m || numCoins == 0.2m || numCoins == 0.5m || numCoins == 1m || numCoins == 2m)
                {
                    allcoins += numCoins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {numCoins}");
                    numCoins = 0;
                }

                Start = Console.ReadLine();
            }

            string products = Console.ReadLine().ToLower();

            while (products != "End")
            {
                if (products == "Nuts" || products == "nuts" || products == "water" || products == "Water" ||
                    products == "crisps" || products == "Crisps" || products == "soda" || products == "Soda" || products == "coke" || products == "Coke")
                {
                    switch (products)
                    {
                        case "nuts":
                        case "Nuts":
                            if (allcoins - Nuts >= 0)
                            {
                                Console.WriteLine("Purchased nuts");
                                allcoins -= Nuts;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;
                        case "water":
                        case "Water":
                            if (allcoins - Water >= 0)
                            {
                                Console.WriteLine("Purchased water");
                                allcoins -= Water;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;
                        case "crisps":
                        case "Crisps":
                            if (allcoins - Crisps >= 0)
                            {
                                Console.WriteLine("Purchased crisps");
                                allcoins -= Crisps;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;
                        case "soda":
                        case "Soda":
                            if (allcoins - Soda >= 0)
                            {
                                Console.WriteLine("Purchased soda");
                                allcoins -= Soda;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;
                        case "coke":
                        case "Coke":
                            if (allcoins - Coke >= 0)
                            {
                                Console.WriteLine("Purchased coke");
                                allcoins -= Coke;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }

                products = Console.ReadLine();
            }

            Change = allcoins;
            Console.WriteLine($"Change: {Change:f2}");

            Console.Read();
        }
    }
}
