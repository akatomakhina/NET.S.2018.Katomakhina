using NUnit.Framework;
using System;
using System.Collections.Generic;
using GSDLogic;

namespace GsdLogicNUnit.Tests
{
    [TestFixture]
    public class TestGSD
    {
        #region Data

        public static IEnumerable<TestCaseData> DataForGcdForTwoNumberTest
        {
            get
            {
                yield return new TestCaseData(-15, 10).Returns(5);
                yield return new TestCaseData(15, -10).Returns(5);
                yield return new TestCaseData(-16, -8).Returns(8);
                yield return new TestCaseData(1, 10).Returns(1);
                yield return new TestCaseData(5, 10).Returns(5);
                yield return new TestCaseData(0, 15).Returns(15);
                yield return new TestCaseData(5, 0).Returns(5);
                yield return new TestCaseData(0, 0).Returns(0);
                yield return new TestCaseData(19, 19).Returns(19);
            }
        }

        public static IEnumerable<TestCaseData> DataForGcdForThreeNumberTest
        {
            get
            {
                yield return new TestCaseData(-5, 10, 15).Returns(5);
                yield return new TestCaseData(1, 10, 100).Returns(1);
                yield return new TestCaseData(2, 0, 4).Returns(2);
                yield return new TestCaseData(11, 7, 8).Returns(1);
                yield return new TestCaseData(124, 416, 112).Returns(4);
                yield return new TestCaseData(217, 341, 713).Returns(31);
                yield return new TestCaseData(486, 600, 186).Returns(6);
            }
        }

        public static IEnumerable<TestCaseData> DataForGcdForArgsTest
        {
            get
            {
                yield return new TestCaseData(new[] { 13, 11, 3 }).Returns(1);
                yield return new TestCaseData(new[] { 322, 12, 488, 4 }).Returns(2);
                yield return new TestCaseData(new[] { 15, 30, 9, 6 }).Returns(3);
                yield return new TestCaseData(new[] { 625, 75, 275, 575 }).Returns(25);
                yield return new TestCaseData(new[] { 33, 121, 77, 209, 253, 165 }).Returns(11);
            }
        }
        #endregion

        #region GDC

        [Test, TestCaseSource(nameof(DataForGcdForTwoNumberTest))]
        public int Gcd_ForTwoNumber(int a, int b)
        {
            return GSDRealization.Gsd(a, b);
        }

        [Test, TestCaseSource(nameof(DataForGcdForThreeNumberTest))]
        public int Gcd_ForThreeNumber(int a, int b, int c)
        {
            return GSDRealization.Gsd(a, b, c);
        }

        [Test, TestCaseSource(nameof(DataForGcdForArgsTest))]
        public int Gcd_ForArgs(int[] a)
        {
            return GSDRealization.Gsd(a);
        }

        [Test]
        public void Gcd_ThrowsArgumentNullException_Null()
        {
            Assert.Throws<ArgumentNullException>(() => GSDRealization.Gsd(null));
        }
        #endregion

        #region GDCBinary

        [Test, TestCaseSource(nameof(DataForGcdForTwoNumberTest))]
        public int GcdBinary_ForTwoNumber(int a, int b)
        {
            return GSDRealization.GcdBinary(a, b);
        }

        [Test, TestCaseSource(nameof(DataForGcdForThreeNumberTest))]
        public int GcdBinary_ForThreeNumber(int a, int b, int c)
        {
            return GSDRealization.GcdBinary(a, b, c);
        }

        [Test, TestCaseSource(nameof(DataForGcdForArgsTest))]
        public int GcdBinary_ForArgs(int[] a)
        {
            return GSDRealization.GcdBinary(a);
        }

        [Test]
        public void GcdBinary_ThrowsArgumentNullException_Null()
        {
            Assert.Throws<ArgumentNullException>(() => GSDRealization.GcdBinary(null));
        }
        #endregion
    }
}
