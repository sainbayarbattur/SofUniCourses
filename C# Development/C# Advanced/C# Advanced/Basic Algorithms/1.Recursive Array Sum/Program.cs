using System;
using System.Linq;

namespace _1._Recursive_Array_Sum
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Sum(Console.ReadLine().Split(" ").Select(int.Parse).ToArray(), 0, 0));
        }

        private static int Sum(int[] array, int index, int sum)
        {
            if (index < array.Length)
            {
                sum += array[index];
                return Sum(array, ++index, sum);
            }

            return sum;
        }
    }
}