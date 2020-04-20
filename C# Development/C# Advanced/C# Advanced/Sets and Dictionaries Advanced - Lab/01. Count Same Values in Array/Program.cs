namespace _01._Count_Same_Values_in_Array
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            var dic = new Dictionary<double, int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (!dic.ContainsKey(input[i]))
                {
                    dic.Add(input[i], 0);
                }

                dic[input[i]]++;
            }

            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}