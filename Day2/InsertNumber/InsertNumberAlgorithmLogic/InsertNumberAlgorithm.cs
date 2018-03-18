// <copyright file="InsertNumberAlgorithm.cs" company="Nastichka Enterprises">
//     Copyright? I dont know what is it.
// </copyright>
// <author>Anastasiya Katomakhina</author>

namespace InsertNumberAlgorithmLogic
{
    using System;

    /// <summary>
    /// The class contains the algorithm for implementing the bit insert.
    /// </summary>
    public class InsertNumberAlgorithm
    {
        #region ConstantField
        /// <summary>
        /// The maximum integer value.
        /// </summary>
        private const int MaxNumber = 0x7fffffff;

        /// <summary>
        /// The maximum bit value.
        /// </summary>
        private const int MaxNumberOfBit = 31;
        #endregion

        #region PublicMethod
        /// <summary>
        /// This method implements the insertion of one number into another by bits.
        /// </summary>
        /// <param name="firstNumber">The number to which the second number will be inserted.</param>
        /// <param name="secondNumber">The number to insert.</param>
        /// <param name="i">Bit i-position.</param>
        /// <param name="j">Bit j-position.</param>
        /// <returns>The method returns a new converted number.</returns>
        public static int InsertNumber(int firstNumber, int secondNumber, int i, int j)
        {
            if (j < i)
            {
                throw new ArgumentException($"{nameof(i)} must be less then {nameof(j)}");
            }

            if (i < 0 || i > MaxNumberOfBit)
            {
                throw new ArgumentOutOfRangeException(nameof(i));
            }

            if (j < 0 || j > MaxNumberOfBit)
            {
                throw new ArgumentOutOfRangeException(nameof(j));
            }

            int amount = j - i + 1;
            int mask;

            mask = MaxNumber >> (MaxNumberOfBit - amount);
            int secondNumberTail = secondNumber & mask;

            mask = MaxNumber >> (MaxNumberOfBit - i);
            int firstNumberTail = firstNumber & mask;

            secondNumberTail = secondNumberTail << i;
            secondNumberTail = secondNumberTail | firstNumberTail;

            mask = MaxNumber >> (MaxNumberOfBit - j - 1);
            return (firstNumber & ~mask) | secondNumberTail;
        }
        #endregion
    }
}
