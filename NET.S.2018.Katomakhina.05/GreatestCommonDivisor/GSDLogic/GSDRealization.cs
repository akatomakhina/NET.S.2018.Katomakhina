// <copyright file="GSD.cs" company="Nastichka Enterprises">
//     Copyright? I dont know what is it.
// </copyright>
// <author>Anastasiya Katomakhina</author>

namespace GSDLogic
{
    using System;

    /// <summary>
    /// The class contains methods that implement the algorithm for finding the greatest common divisor.
    /// </summary>
    public class GSDRealization
    {
        #region PublicMethod

        #region Gsd
        /// <summary>
        /// The public method of implementing a private method for two numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>Returns the calculated greatest common divisor.</returns>
        public static int Gsd(int a, int b)
        {
            return GsdAlgorithm(a, b);            
        }

        /// <summary>
        /// The public method of implementing a private method for three numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <returns>Returns the calculated greatest common divisor.</returns>
        public static int Gsd(int a, int b, int c) => GcdWith3ArgsAlgorithm(Gsd, a, b, c);

        /// <summary>
        /// The public method of implementing a private method for an array of numbers.
        /// </summary>
        /// <param name="args">The received array of integers for computing.</param>
        /// <returns>Returns the calculated greatest common divisor.</returns>
        public static int Gsd(int[] args) => GcdParamsArgsAlgorithm(Gsd, args);
        #endregion

        #region GsdBinary
        /// <summary>
        /// The public method of implementing a private method for two numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>Returns the calculated greatest common divisor.</returns>
        public static int GcdBinary(int a, int b)
        {
            return GcdBinaryAlgorithm(a, b);
        }

        /// <summary>
        /// The public method of implementing a private method for three numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <returns>Returns the calculated greatest common divisor.</returns>
        public static int GcdBinary(int a, int b, int c) => GcdWith3ArgsAlgorithm(GcdBinary, a, b, c);

        /// <summary>
        /// The public method of implementing a private method for an array of numbers.
        /// </summary>
        /// <param name="args">The received array of integers for computing.</param>
        /// <returns>Returns the calculated greatest common divisor.</returns>
        public static int GcdBinary(int[] args) => GcdParamsArgsAlgorithm(GcdBinary, args);
        #endregion

        #endregion

        #region PrivateMethod
        /// <summary>
        /// The method implements the logic of the algorithm for finding the greatest common divisor 
        /// for two numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>Returns the calculated greatest common divisor.</returns>
        private static int GsdAlgorithm(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            a = Math.Abs(a);
            b = Math.Abs(b);

            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return a;
        }

        /// <summary>
        /// The method implements the logic of the algorithm for finding the binary greatest common divisor 
        /// for two numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>Returns the calculated greatest common divisor.</returns>
        private static int GcdBinaryAlgorithm(int a, int b)
        {            
            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }
            a = Math.Abs(a);
            b = Math.Abs(b);
            int shift, t;

            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }

            do
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                if (a > b)
                {
                    t = b;
                    b = a;
                    a = t;
                }

                b -= a;
            }
            while (b != 0);

            return a << shift;
        }

        /// <summary>
        /// The method implements the logic of the algorithm for finding the greatest common divisor 
        /// for three numbers.
        /// </summary>
        /// <param name="method">This parameter determines the received method.</param>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <returns>Returns the calculated greatest common divisor.</returns>
        private static int GcdWith3ArgsAlgorithm(Func<int, int, int> method, int a, int b, int c)
            => method(a, method(b, c));

        /// <summary>
        /// The method implements the logic of the algorithm of finding the greatest common divisor 
        /// for an array of numbers.
        /// </summary>
        /// <param name="method">This parameter determines the received method.</param>
        /// <param name="args">The received array of integers for computing.</param>
        /// <returns>Returns the calculated greatest common divisor.</returns>
        private static int GcdParamsArgsAlgorithm(Func<int, int, int> method, int[] args)
        {
            if (args == null || args.Length == 0)
            {
                throw new ArgumentNullException(nameof(args));
            }

            if (args.Length == 0)
            {
                return 0;
            }

            int result = args[0];
            for (int i = 1; i < args.Length; i++)
            {
                result = method(result, args[i]);
            }

            return result;
        }
        #endregion
    }
}
