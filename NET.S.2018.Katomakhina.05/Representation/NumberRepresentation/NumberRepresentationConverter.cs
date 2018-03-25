// <copyright file="NumberRepresentationConverter.cs" company="Nastichka Enterprises">
//     Copyright? I dont know what is it.
// </copyright>
// <author>Anastasiya Katomakhina</author>

namespace NumberRepresentation
{
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// The class contains an extension method for obtaining a string binary representation 
    /// of a real number of double precision.
    /// </summary>
    public static class NumberRepresentationConverter
    {
        #region PrivateFields
        /// <summary>
        /// The maximum length of bits.
        /// </summary>
        private const int MaxLength = 64;
        #endregion

        #region PublicMethods
        /// <summary>
        /// A public method containing a private method for an extension 
        /// to obtain a string binary representation of a real number of double precision.
        /// </summary>
        /// <param name="number">Number to be represented.</param>
        /// <returns>Binary representation for number.</returns>
        public static string DoubleToBinaryString(this double number)
        {
            return DoubleToBinaryStringLogic(number);
        }
        #endregion

        #region PrivateMethods        
        /// <summary>
        /// Method for extension to obtain a string binary representation 
        /// of a real number of double precision.
        /// </summary>
        /// <param name="number">Number to be represented.</param>
        /// <returns>Binary representation for number.</returns>
        private static string DoubleToBinaryStringLogic(this double number)
        {
            DoubleToLongStruct doubleToLong = new DoubleToLongStruct(number);
            StringBuilder stringForAppend = new StringBuilder("");
            long unity = 1;

            for (var i = 0; i < MaxLength; i++)
            {
                stringForAppend.Append((doubleToLong.LongNumber & (unity << (MaxLength - 1 - i))) != 0 ? '1' : '0');

            }

            return stringForAppend.ToString();
        }
        #endregion

        #region PrivateClass
        /// <summary>
        /// Structure for organizing memory for each field.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private class DoubleToLongStruct
        {
            /// <summary>
            /// The field indicates how much memory will be allocated for this field.
            /// </summary>
            [FieldOffset(0)]
            private long long64bits;

            /// <summary>
            /// The field indicates how much memory will be allocated for this field.
            /// </summary>
            [FieldOffset(0)]
            private double double64bits;

            /// <summary>
            /// Constructor for structure.
            /// </summary>
            /// <param name="doubleNumber">The received number.</param>
            /// <see cref="DoubleToLongStruct"/>
            public DoubleToLongStruct(double doubleNumber)
            {
                double64bits = doubleNumber;
            }

            public long LongNumber => long64bits;
        }
        #endregion
    }
}
