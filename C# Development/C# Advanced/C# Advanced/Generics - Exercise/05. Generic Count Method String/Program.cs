using System;
using System.Collections.Generic;

class GenericCountMethodStrings
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<string> list = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            list.Add(input);
        }

        string comparingElement = Console.ReadLine();
        Console.WriteLine(Compare(list, comparingElement));
    }

    public static int Compare<T>(List<T> list, T element)
      where T : IComparable<T>
    {
        int counter = 0;
        foreach (var item in list)
        {
            if (item.CompareTo(element) > 0)
            {
                counter += 1;
            }
        }
        return counter;
    }
}