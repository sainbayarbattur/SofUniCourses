namespace VowelsCount
{
    using System;
    using System.Text;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            string inputData = Console.ReadLine();
            Console.WriteLine(CountVowels(inputData));

            Console.Read();
        }

        public static int CountVowels(string inputText)
        {
            int countVowels = 0;
            char[] result = inputText.ToCharArray();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == 'A' || result[i] == 'a' || result[i] == 'E' || result[i] == 'e' || result[i] == 'I' || result[i] == 'i' 
                    || result[i] == 'O' || result[i] == 'o' || result[i] == 'U' || result[i] == 'u')
                {
                    countVowels++;
                }
            }
            return countVowels;
        }
    }
}
