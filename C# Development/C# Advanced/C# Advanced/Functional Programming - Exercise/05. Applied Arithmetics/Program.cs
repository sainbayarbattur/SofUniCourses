namespace Problem_5._Applied_Arithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var result = new List<int>(input);

            while (true)
            {
                string currCommand = Console.ReadLine();

                if (currCommand == "end") break;

                switch (currCommand)
                {
                    case "add":
                        result = new List<int>(result.Select(x => x + 1));
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", result));
                        break;
                    case "multiply":
                        result = new List<int>(result.Select(x => x * 2));
                        break;
                    case "subtract":
                        result = new List<int>(result.Select(x => x - 1));
                        break;
                }
            }
        }
    }
}
