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

            var type = typeof(string);

            var currItem = new BoxOfStrings<string>();

            var result = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string currInput = Console.ReadLine();

                string currItemToAdd = currItem.Add(currInput);

                result.Add(currItemToAdd);
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{type}: {item}");
            }
        }
    }
}
