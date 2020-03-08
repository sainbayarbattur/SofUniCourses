namespace Periodic_Table
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var result = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string[] currInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int b = 0; b < currInput.Length; b++)
                {
                    string currChemical = currInput[b];
                    if (!result.Contains(currChemical))
                    {
                        result.Add(currChemical);
                    }
                }
            }

            foreach (var item in result.OrderBy(x => x))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
