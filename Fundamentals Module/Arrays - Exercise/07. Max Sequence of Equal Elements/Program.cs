namespace MaxSequenceOfEqualElements
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int currentSecuence = 1;

            int longestSequence = 1;

            int currentStartIndex = 0;

            int indexBestSequence = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                int previousNumber = numbers[i - 1];
                int currentNumber = numbers[i];
                currentStartIndex = i - currentSecuence;

                if (currentNumber == previousNumber)
                {
                    currentSecuence++;

                    if (currentSecuence > longestSequence)
                    {
                        longestSequence = currentSecuence;
                        indexBestSequence = currentStartIndex;
                    }
                }
                else
                {
                    currentSecuence = 1;
                }
            }
            for (int i = indexBestSequence; i < indexBestSequence + longestSequence; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.Read();
        }
    }
}
