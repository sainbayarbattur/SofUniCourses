using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.__Merge_Sort
{
    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Mergesort<int>.Sort(arr, 0, arr.Length - 1);

            Console.WriteLine(string.Join(" ", arr));
        }
    }

    public class Mergesort<T> where T : IComparable
    {
        public static void Merge(T[] input, int left, int middle, int right)
        {
            T[] leftArray = new T[middle - left + 1];
            T[] rightArray = new T[right - middle];

            Array.Copy(input, left, leftArray, 0, middle - left + 1);
            Array.Copy(input, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    input[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else if (IsLess(leftArray[i], rightArray[j]))
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else
                {
                    input[k] = rightArray[j];
                    j++;
                }
            }
        }

        private static bool IsLess(T first, T second)
        {
            return first.CompareTo(second) <= 0;
        }

        public static void Sort(T[] input, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                Sort(input, left, middle);
                Sort(input, middle + 1, right);

                Merge(input, left, middle, right);
            }
        }
    }
}
