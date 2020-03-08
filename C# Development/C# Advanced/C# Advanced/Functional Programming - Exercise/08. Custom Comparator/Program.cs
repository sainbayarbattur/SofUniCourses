namespace Problem_8._Custom_Comparator
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int, int, int> sortFunc = (a, b) => a.CompareTo(b);
            Action<int[]> print = x => Console.Write(string.Join(' ', x));

            var evenNums = input.Where(x => x % 2 == 0).OrderBy(x => x).ToArray();
            var oddNums = input.Where(x => x % 2 != 0).OrderBy(x => x).ToArray();

            Array.Sort(evenNums, new Comparison<int>(sortFunc));
            Array.Sort(oddNums, new Comparison<int>(sortFunc));

            print(evenNums);
            Console.Write(" ");
            print(oddNums);
            Console.WriteLine();
        }
    }
}
