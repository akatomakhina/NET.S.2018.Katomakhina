using System;
using System.Collections.Generic;

namespace BinarySearchLogic
{
    public class BinarySearcher
    {
        #region public methods

        public static int BinarySearch<T>(T[] array, T value, IComparer<T> comparer) =>
            BinarySearch(array, value, comparer.Compare);

        public static int BinarySearch<T>(T[] array, T value) =>
            BinarySearch(array, value, GetDefaultComparison(array));

        public static int BinarySearch<T>(T[] array, T value, Comparison<T> comparer)
        {           

            int leftIndex = 0;
            int rightIndex = array.Length;
            int mid = 0;

            Validation(array, leftIndex, rightIndex, comparer);

            while (leftIndex < rightIndex)
            {
                mid = leftIndex + (rightIndex - leftIndex) / 2;

                int comparerResult = comparer(array[mid], value);

                if (comparerResult == 0)
                {
                    return mid;
                }

                if (comparerResult < 0)
                {
                    leftIndex = mid + 1;
                }
                else
                {
                    rightIndex = mid - 1;
                }
            }

            return -1;
        }

        #endregion

        #region private methods

        private static Comparison<T> GetDefaultComparison<T>(T[] arr)
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

        private static void Validation<T>(T[] array, int leftIndex, int rightIndex, Comparison<T> comparer)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException($"{nameof(array)} is null");
            }

            if (array.Length == 0)
            {
                return;
            }           

            if (ReferenceEquals(comparer, null))
            {
                comparer = GetDefaultComparison(array);
            }

            ValidationIndex(array.Length, leftIndex, rightIndex);
        }

        private static void ValidationIndex(int arrayLength, int leftIndex, int rightIndex)
        {
            if (leftIndex > rightIndex)
            {
                throw new ArgumentException($"{nameof(rightIndex)} must be greater than {nameof(leftIndex)}");
            }

            if (rightIndex > arrayLength)
            {
                throw new ArgumentException($"{nameof(rightIndex)} must be less than {nameof(arrayLength)}");
            }
        }

        #endregion
    }
}
