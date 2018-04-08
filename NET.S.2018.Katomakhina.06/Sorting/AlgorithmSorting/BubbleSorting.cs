using System;
using System.Collections.Generic;

namespace AlgorithmSorting
{
    public class BubbleSorting
    {
        #region Public methods

        public static void Sort(int[][] jaggedArray, IComparer<int[]> comparator) =>
            BubbleSort(jaggedArray, comparator);

        public static void Sort(int[][] jaggedArray, Comparison<int[]> comparator) =>
            BubbleSort(jaggedArray, new DelegateForSort(comparator));

        #endregion

        #region Private methods

        private static void BubbleSort(int[][] jaggedArray, IComparer<int[]> comparator)
        {
            Validation(jaggedArray, comparator);

            for (int i = 0; i < jaggedArray.Length - 1; i++)
            {
                for (int j = 0; j < jaggedArray.Length - 1; j++)
                {
                    if (comparator.Compare(jaggedArray[j], jaggedArray[j + 1]) > 0)
                    {
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                    }
                }
            }
        }

        private static void Validation(int[][] jaggedArray, IComparer<int[]> comparator)
        {
            if (ReferenceEquals(jaggedArray, null))
            {
                throw new ArgumentException(nameof(jaggedArray));
            }

            if (ReferenceEquals(comparator, null))
            {
                throw new ArgumentException(nameof(comparator));
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                if (ReferenceEquals(jaggedArray[i], null))
                {
                    throw new ArgumentException(nameof(jaggedArray), $"{i}-th nested array in {nameof(jaggedArray)} is null");
                }
            }
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        #endregion
    }
}
