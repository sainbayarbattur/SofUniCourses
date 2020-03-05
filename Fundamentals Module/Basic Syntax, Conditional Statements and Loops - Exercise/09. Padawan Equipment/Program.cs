using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp61
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyHad = double.Parse(Console.ReadLine());
            double countStudents = double.Parse(Console.ReadLine());
            double priceLightbers = double.Parse(Console.ReadLine());
            double priceRobes = double.Parse(Console.ReadLine());
            double priceBelts = double.Parse(Console.ReadLine());
            double freebelts = 0;

            for (double i = countStudents; i >= 1; i /= 6)
            {
                if (i / 6 == 0)
                {
                    break;
                }
                else
                {
                    freebelts++;
                }
            }


            double totalPrice = priceLightbers * (Math.Ceiling(countStudents * 1.1)) + priceRobes * countStudents + priceBelts * (countStudents - (Math.Floor(countStudents / 6)));
            double ex = totalPrice - moneyHad;
            if (totalPrice > moneyHad)
            {
                Console.WriteLine($"Ivan Cho will need {ex:f2}lv more.");
            }
            else
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }

            Console.WriteLine();

            Console.Read();
        }
    }
}
