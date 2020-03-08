namespace _3._Generic_Swap_Method_Strings
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using _03.GenericSwapMethodString;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var box = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                box.Add(int.Parse(Console.ReadLine()));
            }

            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int firstIndex = input[0];

            int secondIndex = input[1];

            Swap(box.Data, firstIndex, secondIndex);

            box.Data.ForEach(x => Console.WriteLine($"{x.GetType()}: {x}"));
        }

        private static void Swap<T>(List<T> box, int firstIndex, int secondIndex)
        {
            var temp = box[firstIndex];

            box[firstIndex] = box[secondIndex];

            box[secondIndex] = temp;
        }
    }
}