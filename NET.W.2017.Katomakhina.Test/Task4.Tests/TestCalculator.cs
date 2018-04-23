using System;
using System.Collections.Generic;
using NUnit.Framework;
//using Task4;
using Task4.Solution;

namespace Task4.Tests
{
    [TestFixture]
    public class TestCalculator
    {
        private readonly List<double> values = new List<double> { 10, 5, 7, 15, 13, 12, 8, 7, 4, 2, 9 };

        [Test]
        public void Test_AverageByMean()
        {
            var calcReal = new CalculatorRealization();

            var calc = new CalculatorClassMean();

            double expected = 8.3636363;

            double actual = calcReal.DoCalc(values, calc);

            Assert.AreEqual(expected, actual, 0.000001);
        }

        [Test]
        public void Test_AverageByMedian()
        {
            var calcReal = new CalculatorRealization();

            var calc = new CalculatorClassMedian();

            double expected = 8.0;

            double actual = calcReal.DoCalc(values, calc);

            Assert.AreEqual(expected, actual, 0.000001);
        }

        [Test]
        public void Test_AverageByMean_Delegate()
        {
            var calcReal = new CalculatorRealization();

            var calc = new CalculatorClassMean();

            double expected = 8.3636363;

            double actual = calcReal.DoCalcWithDelegate(values, calc.CalculateAverage);

            Assert.AreEqual(expected, actual, 0.000001);
        }

        [Test]
        public void Test_AverageByMedian_Delegate()
        {
            var calcReal = new CalculatorRealization();

            var calc = new CalculatorClassMedian();

            double expected = 8.0;

            double actual = calcReal.DoCalcWithDelegate(values, calc.CalculateAverage);

            Assert.AreEqual(expected, actual, 0.000001);
        }
    }
}