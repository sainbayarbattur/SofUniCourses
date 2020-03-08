namespace _6._Generic_Count_Method_Doubles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var n = double.Parse(Console.ReadLine());

            var box = new List<double>();

            for (int i = 0; i < n; i++)
            {
                box.Add(double.Parse(Console.ReadLine()));
            }

            double anotherN = double.Parse(Console.ReadLine());

            var lenght = box.Where(x => x > anotherN).ToList().Count;

            Console.WriteLine(lenght);
        }
    }
}
