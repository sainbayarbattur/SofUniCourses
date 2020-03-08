namespace Fast_Food
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int food = int.Parse(Console.ReadLine());

            var orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var result = new Queue<int>(orders);

            int maxNumber = int.MinValue;

            for (int i = 0; i < orders.Length; i++)
            {
                int currOrder = orders[i];

                food -= currOrder;

                if (maxNumber < currOrder)
                {
                    maxNumber = currOrder;
                }

                if (food >= 0)
                {
                    result.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (result.Count == 0)
            {
                Console.WriteLine(maxNumber);
                Console.WriteLine("Orders complete");
            }
            else if (result.Count > 0)
            {
                Console.WriteLine(maxNumber);
                Console.WriteLine($"Orders left: {string.Join(" ", result)}");
            }
        }
    }
}
