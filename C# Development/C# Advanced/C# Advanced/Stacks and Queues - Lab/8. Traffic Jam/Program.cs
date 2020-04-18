namespace _8._Traffic_Jam
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int numberOfCarsThatCanPassInput = int.Parse(Console.ReadLine());
            int carsCount = 0;
            int numberOfCarsThatCanPass = numberOfCarsThatCanPassInput;

            var queue = new Queue<string>();

            string line = Console.ReadLine();

            while (line != "end")
            {
                if (line == "green")
                {
                    while (queue.Count > 0 && numberOfCarsThatCanPass > 0)
                    {
                        Console.WriteLine(queue.Dequeue() + " passed!");
                        numberOfCarsThatCanPass--;
                        carsCount++;
                    }

                    numberOfCarsThatCanPass = numberOfCarsThatCanPassInput;
                }
                else
                {
                    queue.Enqueue(line);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"{carsCount} cars passed the crossroads.");
        }
    }
}