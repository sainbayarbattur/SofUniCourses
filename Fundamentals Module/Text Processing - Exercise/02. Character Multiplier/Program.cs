namespace MySomeShitProject
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split().ToArray();
            long result = 0;

            string firstData = input[0];
            string secondData = input[1];

            int firstLenght = firstData.Length;
            int secondLenght = secondData.Length;

            int minLenght = Math.Min(firstLenght, secondLenght);

            for (int i = 0; i < minLenght; i++)
            {
                int firstAssciSymbol = firstData[i];
                int secondAssciSymbol = secondData[i];
                result += (firstAssciSymbol * secondAssciSymbol);
            }
            string substring = string.Empty;
            if (firstLenght > secondLenght)
            {
                substring = firstData.Substring(minLenght);
            }
            else if (secondLenght > firstLenght)
            {
                substring = secondData.Substring(minLenght);
            }

            for (int i = 0; i < substring.Length; i++)
            {
                result += substring[i];
            }
            Console.WriteLine(result);
        }
    }
}
