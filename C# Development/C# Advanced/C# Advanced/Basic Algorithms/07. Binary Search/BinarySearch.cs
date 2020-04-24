using System;
using System.Collections.Generic;

namespace _07._Binary_Search
{
    public static class BinarySearch
    {
        public static int Search<T>(T[] arr, T item, int left, int right)
        {
            if (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (Comparer<T>.Default.Compare(item, arr[mid]) == 0)
                {
                    return mid;
                }

                if (Comparer<T>.Default.Compare(item, arr[mid]) > 0)
                {
                    return Search(arr, item, mid + 1, right);
                }

                return Search(arr, item, left, mid - 1);
            }

            return -1;
        }
    }
}