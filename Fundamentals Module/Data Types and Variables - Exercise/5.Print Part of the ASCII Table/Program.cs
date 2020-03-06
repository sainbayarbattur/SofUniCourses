using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            string text = "";
            for (int i = first; i <= second; i++)
            {
                text += (char)i + " ";
            }

            Console.WriteLine(text.TrimEnd());
        }
    }
}
