// <copyright file="StringRepresentationConverter.cs" company="Nastichka Enterprises">
//     Copyright? I dont know what is it.
// </copyright>
// <author>Anastasiya Katomakhina</author>

namespace StringRepresentationLogic
{
    using System;

    /// <summary>
    /// This class contains the implementation of the method of extending 
    /// the output from the string representation 
    /// of the whole positive four-byte number written in the p-ary number system, its decimal value.
    /// </summary>
    public static class StringRepresentationConverter
    {
        #region PublicMethod
        /// <summary>
        /// The public method contains a method implements an algorithm for obtaining 
        /// from the string representation a whole positive four-byte number written 
        /// in the p-ary number system, its decimal value.
        /// </summary>
        /// <param name="source">The received string containing the number.</param>
        /// <param name="notation">An instance of a class that describes the desired number system.</param>
        /// <returns>The method returns a decimal value of the number.</returns>
        /// <exception cref="ArgumentNullException">Source is null.</exception>
        public static int ToDecimalForm(this string source, Notation notation)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return ToDecimalForAlgorithm(source, notation);
        }
        #endregion

        #region PrivateMethod
        /// <summary>
        /// The private method implements an algorithm for obtaining 
        /// from the string representation a whole positive four-byte number written 
        /// in the p-ary number system, its decimal value.
        /// </summary>
        /// <param name="source">The received string containing the number.</param>
        /// <param name="notation">An instance of a class that describes the desired number system.</param>
        /// <returns>The method returns a decimal value of the number.</returns>
        private static int ToDecimalForAlgorithm(string source, Notation notation)
        {
            int index = notation.NotationProperty;

            int result = 0;
            char[] array = source.ToCharArray();

            for (int i = array.Length - 1; i >= 0; i--)
            {
                int temp = notation.GetTheSymbolToDecimal(array[i]);

                checked
                {
                    result += temp * (int)Math.Pow(index, array.Length - i - 1);
                }
            }

            return result;
        }
        #endregion

        #region InternalPublicСlass
        /// <summary>
        /// Internal class containing the abstraction of the number system.
        /// </summary>
        public class Notation
        {
            /// <summary>
            /// A constant field describes a binary number system.
            /// </summary>
            private const int MinNumberSystem = 2;

            /// <summary>
            /// The constant field describes the hexadecimal number system. 
            /// </summary>
            private const int MaxNumberSystem = 16;

            /// <summary>
            /// A string with the characters that we will use for digit.
            /// </summary>
            private const string Alphabet = "0123456789ABCDEF";

            /// <summary>
            /// Initializes a new instance of the <see cref="Notation"/> class with binary basis.
            /// </summary>
            public Notation()
            {
                this.NotationProperty = MinNumberSystem;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Notation"/> class with received basis.
            /// </summary>
            /// <param name="basis">The received basis</param>
            /// <exception cref="ArgumentOutOfRangeException">Basis is out 
            /// of range of the notation borders</exception>
            public Notation(int basis)
            {
                if (basis < MinNumberSystem || basis > MaxNumberSystem)
                {
                    throw new ArgumentOutOfRangeException(nameof(basis));
                }

                this.NotationProperty = basis;
            }

            /// <summary>
            /// Property for class Notation.
            /// </summary>
            public int NotationProperty { get; set; }

            /// <summary>
            /// Convertes received symbols to decimal.
            /// </summary>
            /// <param name="receivedСhar">The received char.</param>
            /// <returns>Returns a character in decimal representation.</returns>
            public int GetTheSymbolToDecimal(char receivedСhar)
            {
                int decimalNumber;
                decimalNumber = Alphabet.IndexOf(char.ToUpper(receivedСhar));

                if (decimalNumber >= this.NotationProperty)
                {
                    throw new ArgumentException(nameof(receivedСhar));
                }

                return decimalNumber;
            }
        }
        #endregion
    }
}
