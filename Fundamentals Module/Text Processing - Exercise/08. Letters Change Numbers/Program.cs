namespace LettersChangeNumbers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            decimal result = 0.00m;

            var upperAlpha = "ABCDEFGHIJKLMNOPQRSTUVWXZ".ToCharArray();

            var lowerAlpha = "abcdefghijklmnopqrstuvwxz".ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {
                decimal number = decimal.Parse(input[i].Substring(1, input[i].Length - 2));

                char firstChar = input[i][0];
                char secondChar = input[i][input[i].Length - 1];

                if (char.IsLower(firstChar))
                {
                    decimal index = firstChar - 'a' + 1;

                    result += (number * index);
                }
                else
                {
                    decimal index = firstChar - 'A' + 1;

                    result += (number / index);
                }

                if (char.IsLower(secondChar))
                {
                    decimal index = secondChar - 'a' + 1;

                    result += index;
                }
                else
                {
                    decimal index = secondChar - 'A' + 1;

                    result -= index;
                }
            }

            Console.WriteLine(result.ToString("0.00"));
        }
    }
}
