using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsertNumberAlgorithmLogic.Test
{
    [TestClass]
    public class InsertNumberAlgorithmTests
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\FileForInsert.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("InsertNumberAlgorithmLogic.Test\\FileForInsert.xml")]

        [TestMethod]
        public void InsertNumber_CheckWithXMLFile()
        {
            int firstNumber = Convert.ToInt32(TestContext.DataRow["FirstNumber"]);
            int secondNumber = Convert.ToInt32(TestContext.DataRow["SecondNumber"]);
            int startIndex = Convert.ToInt32(TestContext.DataRow["StartIndex"]);
            int endIndex = Convert.ToInt32(TestContext.DataRow["EndIndex"]);
            int expected = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);

            var actual = InsertNumberAlgorithm.InsertNumber(firstNumber, secondNumber, startIndex, endIndex);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumber_CheckWithPositiveElement()
        {
            int expected = 27;
            int actual;
            
            actual = InsertNumberAlgorithm.InsertNumber(13, 13, 1, 6);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumber_CheckWithNegativeElement()
        {
            int expected = -11;
            int actual;

            actual = InsertNumberAlgorithm.InsertNumber(-9, -34, 1, 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_ArgumentOutOfRangeException_NegativI()
            => InsertNumberAlgorithm.InsertNumber(0, 15, -10, 30);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_ArgumentOutOfRangeException_GreaterThanTheMaxIOrJ()
            => InsertNumberAlgorithm.InsertNumber(0, 15, Convert.ToInt32(80000000), Convert.ToInt32(80000002));

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_ArgumentOutOfRangeException_NegativJ()
            => InsertNumberAlgorithm.InsertNumber(0, 15, -40, -30);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_ArgumentException_INotBeLessThenJ()
            => InsertNumberAlgorithm.InsertNumber(0, 15, 10, 7);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_ArgumentOutOfRangeException_GreaterThanTheMaxJBit()
            => InsertNumberAlgorithm.InsertNumber(0, 15, 1, 32);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_ArgumentOutOfRangeException_GreaterThanTheMaxIOrJBit()
            => InsertNumberAlgorithm.InsertNumber(0, 15, 32, 33);
    }
}
