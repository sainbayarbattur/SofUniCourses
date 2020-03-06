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

            int totalSum = 0;

            for (int i = 0; i < n; i++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                totalSum += line[0];
            }

            Console.WriteLine($"The sum equals: {totalSum}");
        }
    }
}
