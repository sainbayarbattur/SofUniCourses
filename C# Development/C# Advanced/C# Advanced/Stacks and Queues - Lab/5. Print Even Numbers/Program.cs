namespace _5._Print_Even_Numbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var queue = new Queue<int>(arr);

            var buffer = new Queue<int>();

            while (queue.Count > 0)
            {
                if (queue.Peek() % 2 != 0)
                {
                    queue.Dequeue();
                }
                else
                {
                    buffer.Enqueue(queue.Dequeue());
                }
            }

            Console.WriteLine(string.Join(", ", buffer));
        }
    }
}