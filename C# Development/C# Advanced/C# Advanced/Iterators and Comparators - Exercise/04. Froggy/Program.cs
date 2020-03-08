namespace Problem_4._Froggy
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var lake = new Lake();

            var input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            lake.AddLake(input);

            Console.Write(string.Join(", ",lake.Result));
            Console.WriteLine();
        }
    }
}
