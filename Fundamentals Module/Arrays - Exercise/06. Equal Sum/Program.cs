namespace EqualSums
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rightSum = 0;
            int leftSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                rightSum += numbers[i];
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                rightSum -= numbers[i];

                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    return;
                }
                leftSum += numbers[i];
            }

            Console.WriteLine("no");
            Console.Read();
        }
    }
}
