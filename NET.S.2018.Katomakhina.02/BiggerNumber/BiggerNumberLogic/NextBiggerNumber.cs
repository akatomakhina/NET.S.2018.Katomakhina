// <copyright file="NextBiggerNumber.cs" company="Nastichka Enterprises">
//     Copyright? I dont know what is it.
// </copyright>
// <author>Anastasiya Katomakhina</author>

namespace BiggerNumberLogic
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// The class contains methods that implement the search for the bigger number.
    /// </summary>
    public class NextBiggerNumber
    {
        #region PrivateFields

        /// <summary>
        /// The received number for encapsulation.
        /// </summary>
        private int number;

        #endregion

        #region PublicMethod

        /// <summary>
        /// Finds the bigger number and search time.
        /// </summary>
        /// <param name="number">The received number.</param>
        /// <returns>Retirns tuple: bigger number and elapsed time.</returns>
        public static Tuple<int, TimeSpan> FindNextBiggerNumberTiming(int number)
        {
            Stopwatch time = new Stopwatch();

            time.Start();
            number = FindNextBiggerNumberLogic(number);
            time.Stop();

            return new Tuple<int, TimeSpan>(number, time.Elapsed);
        }

        /// <summary>
        /// A public method in which the method of implementing the search is called. 
        /// Used for encapsulation.
        /// </summary>
        /// <param name="number">The received number.</param>
        /// <returns>The method returns a converted number.</returns>
        public int FindNextBiggerNumber(int number)
        {
            this.number = number;
            return FindNextBiggerNumberLogic(this.number);
        }

        #endregion

        #region PrivateMethod

        /// <summary>
        /// A private method that implements the logic of finding the bigger number.
        /// </summary>
        /// <param name="number">The received number.</param>
        /// <returns>The method returns a converted number.</returns>
        private static int FindNextBiggerNumberLogic(int number)
        {
            string stringNumber = number.ToString();
            int position;

            for (position = stringNumber.Length - 1; position > 0; position--)
            {
                if (stringNumber[position] > stringNumber[position - 1])
                {
                    break;
                }
            }

            if (position == 0)
            {
                return -1;
            }

            char[] charNumber = stringNumber.ToCharArray();

            if (charNumber[position - 1] < charNumber[charNumber.Length - 1])
            {
                Swap(ref charNumber[position - 1], ref charNumber[charNumber.Length - 1]);
            }
            else
            {
                Swap(ref charNumber[position], ref charNumber[position - 1]);
            }

            Array.Reverse(charNumber, position, charNumber.Length - position);
            stringNumber = string.Concat(charNumber);
            return int.Parse(stringNumber);
        }

        /// <summary>
        /// A method that swaps the receiving variables.
        /// </summary>
        /// <param name="a">The first variable.</param>
        /// <param name="b">The second variable.</param>
        private static void Swap(ref char a, ref char b)
        {
            char temporary = a;
            a = b;
            b = temporary;
        }

        #endregion
    }
}