using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RootAlgorithmLogic.Tests
{
    [TestClass]
    public class RootAlgorithmTests
    {
        /*public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\DataForRoot.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("RootAlgorithmLogic.Test\\DataForRoot.xml")]

        [TestMethod]
        public void FindNthRoot_NumberDegreeResultFromXML()
        {
            double number = Convert.ToDouble(TestContext.DataRow["Number"]);
            int degree = Convert.ToInt32(TestContext.DataRow["Degree"]);
            var expected = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);

            var actual = RootAlgorithm.FindNthRoot(number, degree);

            Assert.AreEqual(expected, actual, 0.0001);
        }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\DataForRoot.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("RootAlgorithmLogic.Test\\DataForRoot.xml")]

        [TestMethod]
        public void FindNthRoot_NumberDegreeResultFromXMLWithAccurancy()
        {
            double number = Convert.ToDouble(TestContext.DataRow["Number"]);
            int degree = Convert.ToInt32(TestContext.DataRow["Degree"]);
            double accuracy = Convert.ToDouble(TestContext.DataRow["Accuracy"]);
            var expected = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);

            var actual = RootAlgorithm.FindNthRoot(number, degree, accuracy);

            Assert.AreEqual(expected, actual);
        }*/

        [TestMethod]
        public void FindNthRoot_NumberResultWithPositiveDegree()
        {
            double number = 1;
            int degree = 5;
            int expected = 1;

            var actual = RootAlgorithm.FindNthRoot(number, degree);

            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod]
        public void FindNthRoot_NumberResultWithDouble()
        {
            double number = 0.001;
            int degree = 3;
            double expected = 0.1;

            var actual = RootAlgorithm.FindNthRoot(number, degree);

            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod]
        public void FindNthRoot_NumberResultWithNegativeDegree()
        {
            double number = 97.65625;
            int degree = -5;
            double expected = 0.4;

            var actual = RootAlgorithm.FindNthRoot(number, degree);

            Assert.AreEqual(expected, actual, 0.0001);
        }

        /*[TestMethod]
        public void FindNthRoot_NumberResultWithAccuracy()
        {
            double number = 0.0081;
            int degree = 4;
            double accuracy = 0.1;
            double expected = 0.3;

            var actual = RootAlgorithm.FindNthRoot(number, degree, accuracy);

            Assert.AreEqual(expected, actual);
        }*/

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterDigit_ThrowArgumentOutOfRangeException()
            => RootAlgorithm.FindNthRoot(999.9, 3, -7);
    }
}
