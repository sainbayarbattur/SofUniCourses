namespace Fashion_Boutique
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int capacityOfTheRack = int.Parse(Console.ReadLine());

            var result = new Stack<int>(sequence);

            int realResult = 0;

            int temporaryCap = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                int currValue = sequence[i];

                if (temporaryCap + currValue > capacityOfTheRack)
                {
                    realResult++;
                    temporaryCap = currValue;
                }
                else
                {
                    temporaryCap += currValue;
                }
            }

            Console.WriteLine(realResult + 1);
        }
    }
}
