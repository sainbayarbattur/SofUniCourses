namespace Problem_6._Reverse_and_Exclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int number = int.Parse(Console.ReadLine());

            var result = new List<int>(input);

            result = new List<int>(result.Where(x => x % number != 0).Reverse());

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
