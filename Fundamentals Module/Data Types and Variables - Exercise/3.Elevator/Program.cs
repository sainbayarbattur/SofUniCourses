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
            int p = int.Parse(Console.ReadLine());
            int courses = (int)Math.Ceiling((double)n / p);
            Console.WriteLine(courses);
        }
    }
}
