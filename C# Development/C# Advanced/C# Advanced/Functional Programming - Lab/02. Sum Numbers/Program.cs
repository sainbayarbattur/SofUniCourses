namespace _02._Sum_Numbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(", ").Select(int.Parse).ToList();

            var sum = new Func<List<int>, int>((input) => 
            {
                var sum = 0;

                for (int i = 0; i < input.Count; i++)
                {
                    sum += input[i];
                }

                return sum;
            });

            Console.WriteLine(input.Count);
            Console.WriteLine(sum(input));
        }
    }
}