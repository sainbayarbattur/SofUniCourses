namespace _3._Count_Uppercase_Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            Func<string, bool> filterUppercase = s => Char.IsUpper(s[0]);

            var result = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(filterUppercase)
                .ToList();

            Console.WriteLine(string.Join('\n', result));
        }
    }
}