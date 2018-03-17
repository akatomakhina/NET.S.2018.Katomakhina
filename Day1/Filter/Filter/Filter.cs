﻿// <copyright file="Filter.cs" company="Nastichka Enterprises">
//     Copyright? I dont know what is it.
// </copyright>
// <author>Anastasiya Katomakhina</author>

namespace FilterLogic
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This class realize filtering method.
    /// </summary>
    public class Filter
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

        #region PublicMethod
        /// <summary>
        /// The method forms a list with those numbers that contain the desired digit.
        /// </summary>
        /// <param name="values">The received array.</param>
        /// <param name="filter">The digit that must be contained in the checked number.</param>
        /// <exception cref="ArgumentNullException">An error is returned 
        /// if the array is empty or null reference.</exception>
        /// <exception cref="ArgumentOutOfRangeException">An error is returned 
        /// if the filter number is not natural or zero.</exception>
        /// <returns>Returns a filtered list.</returns>
        public int[] FilterDigit(int[] values, int filter)
        {
            if (values == null || values.Length == 0)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (filter < 0 || filter > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(filter));
            }

            this.numbers = values;
            number = values.Length;
            var list = new List<int>();

            for (int i = 0; i < number; i++)
            {
                if (IsMatch(numbers[i], filter))
                {
                    list.Add(numbers[i]);
                }
            }

            return list.ToArray();
        }
        #endregion

        #region PrivateMethod
        /// <summary>
        /// The method checks whether we have found the right digit.
        /// </summary>
        /// <param name="number">The number that we want to check.</param>
        /// <param name="filter">The digit that must be contained in the checked number.</param>
        /// <returns>Returns the truе if we found the necessary digit and false if not found.</returns>
        private bool IsMatch(int number, int filter)
        {
            do
            {
                if (number % 10 == filter || number % 10 == -filter)
                {
                    return true;
                }

                number /= 10;
            } while (number != 0);

            return false;
        }
        #endregion
    }
}
