namespace Maximum_and_Minimum_Element
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var result = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                switch (input[0])
                {
                    case 1:
                        int topValue = input[1];
                        result.Push(topValue);
                        break;
                    case 2:
                        if (result.Count > 0) result.Pop();
                        break;
                    case 3:
                        if (result.Count > 0) Console.WriteLine(result.Max());
                        break;
                    case 4:
                        if (result.Count > 0) Console.WriteLine(result.Min());
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
