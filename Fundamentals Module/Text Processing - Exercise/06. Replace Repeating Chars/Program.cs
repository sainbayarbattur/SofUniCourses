namespace ReplaceRepeatingChars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            List<char> input = Console.ReadLine().ToCharArray().ToList();
            List<char> result = new List<char>();
            char currChar = ' ';
            char nextChar = ' ';

            for (int i = 0; i < input.Count; i++)
            {
                if (i == input.Count - 1)
                {
                    result.Add(input[input.Count - 1]);
                    break;
                }

                currChar = input[i];
                nextChar = input[i + 1];

                if (currChar != nextChar)
                {
                    result.Add(currChar);
                }
            }

            Console.WriteLine(string.Join("", result));
        }
    }
}
