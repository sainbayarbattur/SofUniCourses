namespace Sets_of_Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var set1 = new List<int>();

            var set2 = new List<int>();

            var result = new List<int>();

            for (int i = 0; i < input.Sum(); i++)
            {
                int currInput = int.Parse(Console.ReadLine());

                if (i < input[0])
                {
                    set1.Add(currInput);
                }
                else if(i >= input[1])
                {
                    set2.Add(currInput);
                }
            }

            //for (int i = 0; i < set1.Count; i++)
            //{
            //    for (int b = 0; b < set2.Count; b++)
            //    {
            //        if (set1[i] == set2[b])
            //        {
            //            result.Add(set1[i]);
            //        }
            //    }
            //}

            Console.WriteLine(string.Join(" ",set1.Intersect(set2)));
        }
    }
}
