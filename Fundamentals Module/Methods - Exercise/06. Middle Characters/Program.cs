namespace MiddleCharacters
{
    using System;
    public class Program
    {
        public static void Main()
        {
            string inputData = Console.ReadLine();

            Console.WriteLine(MiddleCharacter(inputData));

            Console.Read();
        }

        public static string MiddleCharacter(string a)
        {
            string result = string.Empty;
            if (a.Length % 2 == 0)
            {
                result = a[a.Length / 2 - 1].ToString();
                result += a[a.Length / 2].ToString();
            }
            else
            {
                result = a[a.Length / 2].ToString();
            }

            return result;
        }
    }
}
