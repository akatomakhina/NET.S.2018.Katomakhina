using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchLogic
{
    public class BinarySearcher
    {

        public static int BinarySearch<T>(T[] arr, T value, Comparison<T> comparer)
        {
            if (ReferenceEquals(arr, null))
            {
                throw new ArgumentNullException($"{nameof(arr)} is null");
            }

            if (arr.Length == 0)
            {
                return -1;
            }

            if (ReferenceEquals(comparer, null))
            {
                comparer = DefaultComparison(arr);
            }

            int left = 0;
            int right = arr.Length;
            int mid = 0;

            while (left < right)
            {
                mid = left + (right - left) / 2;

                if (comparer(arr[mid], value) == 0)
                    return mid;

                if (comparer(arr[mid], value) > 0)
                    right = mid;
                else
                    left = mid + 1;
            }

            return -(1 + left);
        }

        private static Comparison<T> DefaultComparison<T>(T[] arr)
        {
            if (arr[0] is IComparable<T>)
            {
                return (x, y) => (x as IComparable<T>).CompareTo(y);
            }
            if (arr[0] is IComparable)
            {
                return (x, y) => (x as IComparable).CompareTo(y);
            }
            throw new ArgumentException("there is no comparer");
        }
    }
}
