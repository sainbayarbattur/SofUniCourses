namespace Problem_3._Custom_Min_Function
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList().Min();

            Console.WriteLine(input);
        }
    }
}
