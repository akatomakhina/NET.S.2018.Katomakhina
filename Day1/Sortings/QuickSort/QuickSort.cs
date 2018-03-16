// <copyright file="QuickSort.cs" company="Nastichka Enterprises">
//     Copyright? I dont know what is it.
// </copyright>
// <author>Anastasiya Katomakhina</author>

namespace QuickSortLogic
{
    using System;

    /// <summary>
    /// This class describes the quicksort implementation.
    /// </summary>
    public class QuickSort
    {
        #region PrivateFields
        /// <summary>
        /// Original array.
        /// </summary>
        private int[] numbers;

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
        public void SortByQuickSorting(int[] values)
        {
            if (values == null || values.Length == 0)
            {
                throw new ArgumentNullException(nameof(values));
            }

            this.numbers = values;
            number = values.Length;
            Quicksort(0, number - 1);
        }

        /// <summary>
        /// The method checks whether the array is sorted correctly.
        /// </summary>
        /// <param name="values">The received array.</param>
        /// <returns>Returns true or false, depending on the result.</returns>
        public bool IsQuickSorting(int[] values)
        {
            int[] arrayWithQuicksort = values;
            int[] arrayWithArraysort = values;
            QuickSort merge = new QuickSort();
            Array.Sort(arrayWithArraysort);
            merge.SortByQuickSorting(arrayWithQuicksort);
            if (!arrayWithArraysort.Equals(arrayWithQuicksort))
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
        /// We get the pivot element from the middle of the list to divide the array into two lists.
        /// If the current value from the left list is smaller than the pivot element 
        /// then get the next element from the left list.
        /// If the current value from the right list is larger than the pivot element 
        /// then get the next element from the right list.
        /// If we have found a value in the left list which is larger than the pivot element 
        /// and if we have found a value in the right list which is smaller than the pivot element 
        /// then we exchange the values.
        /// As we are done we can increase left element and right element.
        /// Then we call the recursion.
        /// </summary>
        /// <param name="left">The leftmost element of the array.</param>
        /// <param name="right">The rightmost element of the array.</param>
        private void Quicksort(int left, int right)
        {
            int i = left;
            int j = right;

            int pivot = numbers[left + ((right - left) / 2)];

            while (i <= j)
            {
                while (numbers[i] < pivot)
                {
                    i++;
                }
              
                while (numbers[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    Exchange(i, j);
                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                Quicksort(left, j);
            }

            if (i < right)
            {
                Quicksort(i, right);
            }
        }

        /// <summary>
        /// The method exchange the two elements with a third variable.
        /// </summary>
        /// <param name="left">The leftmost element of the array.</param>
        /// <param name="right">The rightmost element of the array.</param>
        private void Exchange(int left, int right)
        {
            int i = left;
            int j = right;
            int temporary = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temporary;
        }
        #endregion
    }
}
