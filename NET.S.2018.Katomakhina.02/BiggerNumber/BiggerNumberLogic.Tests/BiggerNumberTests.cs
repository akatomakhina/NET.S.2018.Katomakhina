using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BiggerNumberLogic.Tests
{
    [TestClass]
    public class BiggerNumberTests
    {
        NextBiggerNumber nextNumber = new NextBiggerNumber();

        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\FileForSearch.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("BiggerNumberLogic.Tests\\FileForSearch.xml")]

        [TestMethod]
        public void MSUnitTest_Insert_CorrectInputValues_PositiveTest()
        {
            int actual;
            int expected = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);

            actual = nextNumber.FindNextBiggerNumber(Convert.ToInt32(TestContext.DataRow["Actual"]));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NextBiggerNumber_4124_Returned4142()
        {
            int number = 4124;
            int expected = 4142;
            int actual = nextNumber.FindNextBiggerNumber(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NextBiggerNumber_TestWithNegativeNumber()
        {
            int number = -513;
            int expected = -531;
            int actual = nextNumber.FindNextBiggerNumber(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NextBiggerNumber_TestWithNonexistentBiggerNumber()
        {
            int number = 762;
            int expected = -1;
            int actual = nextNumber.FindNextBiggerNumber(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NextBiggerNumber_TestWithZero()
        {
            int number = 0;
            int expected = -1;
            int actual = nextNumber.FindNextBiggerNumber(number);

            Assert.AreEqual(expected, actual);
        }
    }
}
