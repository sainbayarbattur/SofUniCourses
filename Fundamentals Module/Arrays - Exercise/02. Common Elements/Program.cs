namespace CommonElements
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            string[] firsCompareData = Console.ReadLine().Split();
            string[] secondCompareData = Console.ReadLine().Split();

            for (int i = 0; i <= firsCompareData.Length - 1; i++)
            {
                for (int b = 0; b <= secondCompareData.Length - 1; b++)
                {
                    if (firsCompareData[i] == secondCompareData[b])
                    {
                        Console.Write(firsCompareData[i] + " ");
                    }
                }
            }

            Console.Read();
        }
    }
}
