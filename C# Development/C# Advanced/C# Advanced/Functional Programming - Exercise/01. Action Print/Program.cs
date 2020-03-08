namespace Action_Point
{
    using System;
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Print(input);
        }

        public static void Print(string[] input)
        {
            foreach (var name in input)
            {
                Console.WriteLine(name);
            }
        }
    }
}

