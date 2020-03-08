namespace Problem_4._Find_Evens_or_Odds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string type = Console.ReadLine();

            var arr = new List<int>();

            int i = input[0];

            while (i <= input[1])
            {
                arr.Add(input[0]++);
                i++;
            }

            Console.WriteLine(string.Join(" ", Select(arr, type)));
        }

        public static List<int> Select(List<int> range, string type)
        {
            var result = new List<int>();

            if (type == "odd")
            {
                result = new List<int>(range.Where(x => x % 2 != 0));
            }
            else if (type == "even")
            {
                result = new List<int>(range.Where(x => x % 2 == 0));
            }

            return result;
        }
    }
}
