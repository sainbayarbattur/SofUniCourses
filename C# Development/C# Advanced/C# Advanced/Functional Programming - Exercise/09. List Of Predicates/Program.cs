namespace Problem_9._List_of_Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var result = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                result.Add(i);
            }

            for (int i = 0; i < input.Count; i++)
            {
                result = result.Where(x => x % input[i] == 0).ToList();
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
