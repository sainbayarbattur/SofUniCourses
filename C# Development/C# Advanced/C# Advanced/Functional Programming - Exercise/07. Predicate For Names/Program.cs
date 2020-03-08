namespace Problem_7._Predicate_for_Names
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToList();

            var result = new List<string>(input);

            result = new List<string>(result.Where(x => x.Length <= n));

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
