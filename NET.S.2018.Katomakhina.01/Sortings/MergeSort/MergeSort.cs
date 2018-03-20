// <copyright file="MergeSort.cs" company="Nastichka Enterprises">
//     Copyright? I dont know what is it.
// </copyright>
// <author>Anastasiya Katomakhina</author>

namespace MergeSortLogic
{
    using System;

    /// <summary>
    /// This class describes the mergesort implementation.
    /// </summary>
    public class MergeSort
    {
        #region PrivateFields
        /// <summary>
        /// Original array.
        /// </summary>
        private int[] numbers;

        /// <summary>
        /// An auxiliary array in which we sort the original array.
        /// </summary>
        private int[] helper;

        /// <summary>
        /// The number of elements in the array.
        /// </summary>
        private int number;

        #endregion

        #region PublicMethods
        /// <summary>
        /// In the method we check for empty or null array.
        /// </summary>
        /// <param name="values">The received array.</param>
        /// <exception cref="ArgumentNullException">An error is returned 
        /// if the array is empty or null reference.</exception>
        public void SortByMergeSorting(int[] values)
        {
            if (values == null || values.Length == 0)
            {
                throw new ArgumentNullException(nameof(values));
            }

            this.numbers = values;
            number = values.Length;
            this.helper = new int[number];
            Mergesort(0, number - 1);
        }

        /// <summary>
        /// The method checks whether the array is sorted correctly.
        /// </summary>
        /// <param name="values">The received array.</param>
        /// <returns>Returns true or false, depending on the result.</returns>
        public bool IsMergeSorting(int[] values)
        {
            int[] arrayWithMergesort = values;
            int[] arrayWithArraysort = values;
            MergeSort merge = new MergeSort();
            Array.Sort(arrayWithArraysort);
            merge.SortByMergeSorting(arrayWithMergesort);
            if (!arrayWithArraysort.Equals(arrayWithMergesort))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region PrivateMethods
        /// <summary>
        /// We check if low is smaller than high, if not then the array is sorted.
        /// We get the index of the element which is in the middle 
        /// and then sort the left side of the array, sort the right side of the array
        /// and combine them both.
        /// </summary>
        /// <param name="left">The leftmost element of the array.</param>
        /// <param name="right">The rightmost element of the array.</param>
        private void Mergesort(int left, int right)
        {
            if (left < right)
            {
                int middle = left + ((right - left) / 2);
                Mergesort(left, middle);
                Mergesort(middle + 1, right);
                MergesortRealization(left, middle, right);
            }
        }

        /// <summary>
        /// We copy both parts into the helper array.
        /// Then we copy the smallest values from either the left or the right side back to the original array
        /// and copy the rest of the left side of the array into the target array.
        /// Since we are sorting in-place any leftover elements from the right side are already 
        /// at the right position.
        /// </summary>
        /// <param name="left">The leftmost element of the array.</param>
        /// <param name="middle">The middle element of the array.</param>
        /// <param name="right">The rightmost element of the array.</param>
        private void MergesortRealization(int left, int middle, int right)
        {
            for (int n = left; n <= right; n++)
            {
                helper[n] = numbers[n];
            }

            int i = left;
            int j = middle + 1;
            int k = left;

            while (i <= middle && j <= right)
            {
                if (helper[i] <= helper[j])
                {
                    numbers[k] = helper[i];
                    i++;
                }
                else
                {
                    numbers[k] = helper[j];
                    j++;
                }

                k++;
            }

            while (i <= middle)
            {
                numbers[k] = helper[i];
                k++;
                i++;
            }
        }
        #endregion
    }
}
