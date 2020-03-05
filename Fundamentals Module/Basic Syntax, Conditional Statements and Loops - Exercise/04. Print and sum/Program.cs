using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp60
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int result = 0;
            int finalresult = 0;
            for (int i = 0; i < (secondNumber + 1) - firstNumber; i++)
            {
                result = firstNumber;
                result += i;
                finalresult += result;
                Console.Write(result + " ");
            }

            Console.WriteLine();
            Console.Write($"Sum: {finalresult}");
            Console.Read();
        }
    }
}
