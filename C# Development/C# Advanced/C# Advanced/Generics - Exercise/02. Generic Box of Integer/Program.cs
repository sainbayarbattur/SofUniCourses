namespace _1_GenericBoxofString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var type = typeof(int);

            var currItem = new BoxOfStrings<int>();

            var result = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int currInput = int.Parse(Console.ReadLine());

                int currItemToAdd = currItem.Add(currInput);

                result.Add(currItemToAdd);
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{type}: {item}");
            }
        }
    }
}
