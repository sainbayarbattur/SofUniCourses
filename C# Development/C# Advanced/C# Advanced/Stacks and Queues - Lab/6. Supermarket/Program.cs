namespace _6._Supermarket
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            var buffer = new Queue<string>();

            while (line != "End")
            {
                if (line == "Paid")
                {
                    Console.WriteLine(string.Join('\n', buffer));
                    buffer.Clear();
                }
                else buffer.Enqueue(line);

                line = Console.ReadLine();
            }

            Console.WriteLine($"{buffer.Count} people remaining.");
        }
    }
}