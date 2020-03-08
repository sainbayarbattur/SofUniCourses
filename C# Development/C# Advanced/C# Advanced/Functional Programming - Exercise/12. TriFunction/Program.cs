namespace Problem_13._TriFunction
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Console.ReadLine()
                .Split()
                .FirstOrDefault(x => x.ToCharArray()
                .Select(y => (int)y)
                .Sum() >= n));
        }
    }
}
