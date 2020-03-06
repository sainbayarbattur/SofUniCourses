namespace ReplaceRepeatingChars
{
    using System;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split('\\').ToArray();
            string[] result = input[input.Length - 1].Split('.');
            Console.WriteLine($"File name: {result[0]}");
            Console.WriteLine($"File extension: {result[1]}");
        }
    }
}
