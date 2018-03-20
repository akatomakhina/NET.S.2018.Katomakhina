using NUnit.Framework;
using System;
using System.Collections.Generic;
using InsertNumberAlgorithmLogic;

namespace InsertNumberAlgorithmLogicNUnit.Test
{
    [TestFixture]
    public class InsertNumberAlgorithmNUnit
    {
        public static IEnumerable<TestCaseData> TestDataForInsertion
        {
            get
            {
                yield return new TestCaseData(8, 15, 0, 0).Returns(9);
                yield return new TestCaseData(0, 15, 30, 30).Returns(1073741824);
                yield return new TestCaseData(0, 15, 0, 30).Returns(15);
                yield return new TestCaseData(int.MaxValue, int.MaxValue, 3, 5).Returns(int.MaxValue);
                yield return new TestCaseData(15, int.MaxValue, 3, 5).Returns(63);
                yield return new TestCaseData(15, 15, 1, 3).Returns(15);
                yield return new TestCaseData(15, 15, 1, 4).Returns(31);
                yield return new TestCaseData(15, -15, 0, 4).Returns(17);
                yield return new TestCaseData(15, -15, 1, 4).Returns(3);
                yield return new TestCaseData(-8, -15, 1, 4).Returns(-30);

            }
        }

        [Test, TestCaseSource(nameof(TestDataForInsertion))]
        public int InsertNumber_Data_Number(int firstNumber, int secondNumber, int i, int j)
        {
            return InsertNumberAlgorithm.InsertNumber(firstNumber, secondNumber, i, j);
        }

        [TestCase(11, 23, -1, 5)]
        [TestCase(11, 23, -3, -1)]
        [TestCase(11, 23, 32, 33)]
        [TestCase(11, 23, 5, 32)]
        public void InsertNumber_ThrowsArgumentOutOfRangeException_IOrJBit(int firstNumber, int secondNumber, int i, int j)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => InsertNumberAlgorithm.InsertNumber(firstNumber, secondNumber, i, j));
        }

        [TestCase(14, 37, 7, 5)]
        public void InsertNumber_ArgumentException_INotBeLessThenJ(int firstNumber, int secondNumber, int i, int j)
        {
            Assert.Throws<ArgumentException>(() => InsertNumberAlgorithm.InsertNumber(firstNumber, secondNumber, i, j));
        }
    }
}
