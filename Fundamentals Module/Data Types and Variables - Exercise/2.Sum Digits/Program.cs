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
            int n = int.Parse(Console.ReadLine());
            int digit = 0;

            while (n > 0)
            {
                digit += n % 10;
                n /= 10;
            }

            Console.WriteLine(digit);
            Console.Read();
        }
    }
}
