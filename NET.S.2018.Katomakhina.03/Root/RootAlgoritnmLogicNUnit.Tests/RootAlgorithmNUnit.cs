using NUnit.Framework;
using System;
using RootAlgorithmLogic;

namespace RootAlgorithmLogicNUnit.Tests
{
    [TestFixture]
    public class RootAlgorithmNUnit
    {
        [TestCase(1, 5, 1)]
        [TestCase(8, 3, 2)]
        [TestCase(0.001, 3, 0.1)]
        [TestCase(0.04100625, 4, 0.45)]
        [TestCase(0.0279936, 7, 0.6)]
        [TestCase(97.65625, -5, 0.4)]
        public static void FindNthRoot_NumberDegreeResult(double number, int degree, double expected)
        {
            double actual = RootAlgorithm.FindNthRoot(number, degree);
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public static void FindNthRoot_NumberDegreePrecisionResult(double number, int degree,
            double precision, double expected)
        {
            double actual = RootAlgorithm.FindNthRoot(number, degree, precision);
            Assert.AreEqual(expected, actual, precision);
        }

        [TestCase(8, 15, -7, -5)]
        [TestCase(8, 15, -0.6, -0.1)]
        public void FindNthRoot_ArgumentOutOfRangeException(double number, int degree,
            double precision, double expected)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => RootAlgorithm.FindNthRoot(number, degree, precision));
        }
    }
}
