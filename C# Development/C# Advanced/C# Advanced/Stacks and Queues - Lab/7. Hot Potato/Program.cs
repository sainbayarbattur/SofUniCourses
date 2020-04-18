namespace _7._Hot_Potato
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var kids = new Queue<string>(Console.ReadLine().Split(' '));
            int rotation = int.Parse(Console.ReadLine());

            while (kids.Count != 1)
            {
                for (int i = 1; i <= rotation; i++)
                {
                    if (i == rotation) 
                    {
                        Console.WriteLine($"Removed {kids.Dequeue()}"); 
                    }
                    else
                    {
                        kids.Enqueue(kids.Dequeue());
                    }
                }
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}