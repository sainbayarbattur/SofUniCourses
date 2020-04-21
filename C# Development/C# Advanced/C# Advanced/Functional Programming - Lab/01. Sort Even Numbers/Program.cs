namespace _01._Sort_Even_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(", ").Select(int.Parse).ToList();

            Action<List<int>> filter = new Action<List<int>>((input) => 
            {
                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i] % 2 != 0)
                    {
                        input.RemoveAt(i);
                        i--;
                    }
                }
            });

            filter(input);

            input = input.OrderBy(i => i).ToList();

            Console.WriteLine(string.Join(", ", input));
        }
    }
}