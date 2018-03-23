// <copyright file="RootAlgorithm.cs" company="Nastichka Enterprises">
//     Copyright? I dont know what is it.
// </copyright>
// <author>Anastasiya Katomakhina</author>

namespace RootAlgorithmLogic
{
    using System;

    /// <summary>
    /// The class contains an implementation of computing the root of the n-degree.
    /// </summary>
    public class RootAlgorithm
    {
        #region PublicMethod
        /// <summary>
        /// The public method contains a method that describes the logic of implementing the calculation of the n-degree root.
        /// </summary>
        /// <param name="number">A received real number.</param>
        /// <param name="degree">A received n-degree.</param>
        /// <param name="accuracy">Adjusted accuracy.</param>
        /// <returns>The calculated value.</returns>
        public static double FindNthRoot(double number, int degree, double accuracy = 0.0001)
        {
            if (accuracy < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(accuracy));
            }

            return FindRootRealization(number, degree, accuracy);
        }
        #endregion

        #region PrivateMethod
        /// <summary>
        /// The private method describes the logic of implementing the calculation of the n-degree root.
        /// If the degree is negative, then we convert it into a fraction with a positive degree.
        /// x0 - primary assumption.        
        /// Next, a formula from Wikipedia, where n is a degree, A is the number 
        /// from which we extract the root ((1/n)*((n-1)*xk + (A/xk^(n-1)))).
        /// Repeat this step until the specified accuracy is achieved.
        /// </summary>
        /// <param name="number">A received real number.</param>
        /// <param name="degree">A received n-degree.</param>
        /// <param name="accuracy">Adjusted accuracy.</param>
        /// <returns>The calculated value.</returns>
        private static double FindRootRealization(double number, int degree, double accuracy)
        {
            if (degree < 0)
            {
                number = 1.0 / number;
                degree *= -1;
            }

            double x0 = 1;
            double xk = 1.0 / degree * ((degree - 1) * x0 + number / Math.Pow(x0, degree - 1));

            while (Math.Abs(xk - x0) > accuracy)
            {
                x0 = xk;
                xk = 1.0 / degree * ((degree - 1) * x0 + number / Math.Pow(x0, degree - 1));
            }

            return xk;
        }
        #endregion
    }
}
