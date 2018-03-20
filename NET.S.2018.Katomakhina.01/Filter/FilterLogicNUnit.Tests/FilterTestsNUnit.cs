using System;
using NUnit.Framework;
using FilterLogic;

namespace FilterLogicNUnit.Tests
{
    [TestFixture]
    public class FilterTestsNUnit
    {
        public const int FILTER = 3;
        Filter listFilter = new Filter();
        private static int emptyLength = 0;
        private int[] emptyArray = new int[emptyLength];
        int[] array = new int[] { 1, -3, 3, 15, -14 };

        [Test]
        [TestCase(new int[] { 1, 2, 22, -90, -44, 18, -88, 81, 19, -42, 20, -51, -25, 14, 554 }, new int[] { }, FILTER)]
        [TestCase(new int[] { 1, -90, 3, -15, -13, 1, 100, 33, 0, 2, -37, -51, -23, 14, 334 }, new int[] { 3, -13, 33, -37, -23, 334 }, FILTER)]
        public void FilterDigit_FilteredArray(int[] array, int[] expected, int filter)
        {
            int[] actual = listFilter.FilterDigit(array, filter);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterDigit_ThrowArgumentNullException_Null()
            => Assert.Throws<ArgumentNullException>(() => listFilter.FilterDigit(null, FILTER));

        [Test]
        public void FilterDigit_ThrowArgumentNullException_Empty()
            => Assert.Throws<ArgumentNullException>(() => listFilter.FilterDigit(emptyArray, FILTER));

        [Test]
        public void FilterDigit_ThrowArgumentOutOfRangeExceptiony()
            => Assert.Throws<ArgumentOutOfRangeException>(() => listFilter.FilterDigit(array, 13));
    }
}
