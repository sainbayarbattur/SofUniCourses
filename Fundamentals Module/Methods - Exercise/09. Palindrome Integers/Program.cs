namespace PalindromeIntegers
{
    using System;
    public class Program
    {
        public static void Main()
        {
            string inputData = Console.ReadLine();
            while (inputData != "END")
            {
                PalindromeIntegers(inputData);
                inputData = Console.ReadLine();
            }
            Console.Read();
        }

        public static void PalindromeIntegers(string data)
        {
            string isEnd = string.Empty;

            string backwardData = string.Empty;

            for (int i = data.Length - 1; i >= 0; i--)
            {
                backwardData += data[i];
            }

            if (backwardData == data)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
