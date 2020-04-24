namespace _07._Binary_Search
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int item = int.Parse(Console.ReadLine());

            var index = BinarySearch.Search(arr, item, 0, arr.Length - 1);
            Console.WriteLine(index);
        }
    }
}