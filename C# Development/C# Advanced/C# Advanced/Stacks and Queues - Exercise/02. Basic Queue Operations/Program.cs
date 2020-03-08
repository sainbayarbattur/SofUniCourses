namespace Basic_Queue_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var firstInupt = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int firstNumber = firstInupt[0];

            int numberToPopOut = firstInupt[1];

            int numberLookingFor = firstInupt[2];

            var secondInupt = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            var stack = new Queue<int>();

            bool isThereANumber = false;

            foreach (var digit in secondInupt)
            {
                stack.Enqueue(digit);
            }

            for (int i = 0; i < numberToPopOut; i++)
            {
                stack.Dequeue();
            }

            int smallestNumber = int.MaxValue;

            foreach (var digit in stack)
            {
                if (smallestNumber > digit)
                {
                    smallestNumber = digit;
                }

                if (numberLookingFor == digit)
                {
                    isThereANumber = true;
                    break;
                }
                else
                {
                    isThereANumber = false;
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (isThereANumber)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(smallestNumber);
            }
        }
    }
}
