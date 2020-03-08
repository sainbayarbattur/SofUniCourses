namespace Unique_Usernames
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var result = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string currInput = Console.ReadLine();

                if (!result.Contains(currInput))
                {
                    result.Add(currInput);
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
