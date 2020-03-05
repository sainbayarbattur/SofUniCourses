using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp58
{
    public class Program
    {
        static public void Main()
        {
            int person = int.Parse(Console.ReadLine());
            string neshtositam = Console.ReadLine();
            string dayOftheWeek = Console.ReadLine();
            double price = 0;
            double allprice = 0;

            if (neshtositam == "Students")
            {
                switch (dayOftheWeek)
                {
                    case "Friday":
                        price = 8.45;
                        break;
                    case "Saturday":
                        price = 9.80;
                        break;
                    case "Sunday":
                        price = 10.46;
                        break;
                }

                allprice = price * person;

                if (person >= 30)
                {
                    allprice -= allprice * 15 / 100;
                }
            }
            else if (neshtositam == "Business")
            {
                switch (dayOftheWeek)
                {
                    case "Friday":
                        price = 10.90;
                        break;
                    case "Saturday":
                        price = 15.60;
                        break;
                    case "Sunday":
                        price = 16;
                        break;
                }

                allprice = price * person;

                if (person >= 100)
                {
                    allprice -= 10 * price;
                }
            }
            else if (neshtositam == "Regular")
            {
                switch (dayOftheWeek)
                {
                    case "Friday":
                        price = 15;
                        break;
                    case "Saturday":
                        price = 20;
                        break;
                    case "Sunday":
                        price = 22.50;
                        break;
                }

                allprice = price * person;

                if (person >= 10 && person <= 20)
                {
                    allprice -= allprice * 5 / 100;
                }
            }

            Console.WriteLine($"Total price: {allprice:f2}");
        }
    }
}
