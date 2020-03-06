namespace CharactersInRange
{
    using System;
    public class Program
    {
        public static void Main()
        {
            string firstText = Console.ReadLine();
            string secondText = Console.ReadLine();

            char charFirstText = char.Parse(firstText);
            char charSecondText = char.Parse(secondText);

            AllCharsBetween(charFirstText, charSecondText);
            Console.Read();
        }

        public static void AllCharsBetween (char firstChar, char secondChar)
        {
            char start = ' ';
            char end = ' ';
            if (firstChar > secondChar)
            {
                start = secondChar;
                end = firstChar;
            }
            else if(secondChar > firstChar)
            {
                start = firstChar;
                end = secondChar;
            }
            else
            {
                Console.WriteLine(firstChar);
            }

            for (int i = start + 1; i < end; i++)
            {
                Console.Write((char)i);
                Console.Write(" ");
            }
        }
    }
}
