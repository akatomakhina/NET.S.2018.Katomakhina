using System;

namespace BinarySearchLogic
{
    public class BinarySearcher
    {
        public static int BinarySearch<T>(T[] array, T value, Comparison<T> comparer)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException($"{nameof(array)} is null");
            }

            if (array.Length == 0)
            {
                return -1;
            }

            int first = 0;
            int last = array.Length;
            int mid = 0;

            while (first < last)
            {
                mid = first + (last - first) / 2;

                if (comparer(array[mid], value) == 0)
                    return mid;

                if (comparer(array[mid], value) > 0)
                    last = mid;
                else
                    first = mid + 1;
            }

            return -(1 + first);
        }
    }
}
