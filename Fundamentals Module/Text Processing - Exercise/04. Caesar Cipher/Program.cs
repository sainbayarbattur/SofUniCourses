namespace CaesarCipher
{
    using System;
    public class Program
    {
        public static void Main()
        {
            char[] input = Console.ReadLine().ToCharArray();
            int result = 0;

            foreach (char item in input)
            {
                result = item + 3;
                Console.Write((char)result);
            }
        }
    }
}