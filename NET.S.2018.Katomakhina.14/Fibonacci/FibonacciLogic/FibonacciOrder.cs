using System;
using System.Collections.Generic;
using System.Numerics;

namespace FibonacciLogic
{
    /// <summary>
    /// The class contains the logic of working with Fibonacci numbers.
    /// </summary>
    public class FibonacciOrder
    {
        /// <summary>
        /// The method generates a sequence of Fibonacci numbers.
        /// </summary>
        /// <param name="number">Number of elements in sequence to be generated.</param>
        /// <returns>Order of numbers.</returns>
        /// <exception cref="ArgumentException">An exception is thrown if the number is negative.</exception>
        public static IEnumerable<BigInteger> GenerateOrder(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"{nameof(number)} can't be negative");
            }

            return GenerateHelper();

            IEnumerable<BigInteger> GenerateHelper()
            {
                BigInteger a = -1;
                BigInteger b = 1;

                for (int i = 0; i < number; i++)
                {
                    BigInteger sum = a + b;
                    a = b;
                    b = sum;
                    yield return sum;
                }
            }
        }
    }
}
