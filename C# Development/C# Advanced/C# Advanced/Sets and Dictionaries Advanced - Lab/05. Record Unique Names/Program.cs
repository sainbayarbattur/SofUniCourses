namespace _05._Record_Unique_Names
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var set = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                set.Add(name);
            }

            Console.WriteLine(string.Join('\n', set));
        }
    }
}