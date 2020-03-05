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
            int age = int.Parse(Console.ReadLine());

            if (age <= 2)
            {
                Console.WriteLine("baby");
            }
            else if (age <= 13)
            {
                Console.WriteLine("child");
            }
            else if (age <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if (age <= 65)
            {
                Console.WriteLine("adult");
            }
            else if (age >= 66)
            {
                Console.WriteLine("elder");
            }

            Console.Read();
        }
    }
}