namespace ChangeList
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string token = Console.ReadLine();

            while (token != "end")
            {
                if (token.Split()[0] == "Delete")
                {
                    int rNumber = int.Parse(token.Split()[1]);
                    numbers.RemoveAll(x => x == rNumber);
                }
                else
                {
                    int insert = int.Parse(token.Split()[2]);
                    int iNumber = int.Parse(token.Split()[1]);
                    numbers.Insert(insert, iNumber);
                }

                token = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
