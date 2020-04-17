namespace Cups_and_Bottles
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var cupsInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

            var bottlesInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

            var cups = new Stack<int>(cupsInput.Reverse());

            var bottles = new Stack<int>(bottlesInput);

            int wastedWater = 0;

            while (bottles.Count != 0 && cups.Count != 0)
            {
                int currBottle = bottles.Pop();
                int currCup = cups.Pop();

                if (currBottle >= currCup)
                {
                    wastedWater += currBottle - currCup;
                }
                else
                {
                    cups.Push(currCup - currBottle);
                }
            }

            if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
