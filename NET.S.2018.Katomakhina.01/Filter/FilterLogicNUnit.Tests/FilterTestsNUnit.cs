using System;
using NUnit.Framework;
using FilterLogic;

namespace FilterLogicNUnit.Tests
{
    [TestFixture]
    public class FilterTestsNUnit
    {
        [Test]
        [TestCase(new int[] { 1, 2, 22, -90, -44, 18, -88, 81, 19, -42, 20, -51, -25, 14, 554 }, 
            new int[] { 2, 22, -90, -44, 18, -88, -42, 20, 14, 554 })]
        public void FilterDigit_FilteredArray_Even(int[] array, int[] expected)
        {
            int[] actual = FilterRealization.Filter.FilterDigit(array, new FilterLogic.EvenNumbers());

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 22, -90, -44, 18, -88, 81, 19, -42, 20, -51, -25, 14, 554 },
            new int[] { 1, 81, 19, -51, -25})]
        public void FilterDigit_FilteredArray_Odd(int[] array, int[] expected)
        {
            int[] actual = FilterRealization.Filter.FilterDigit(array, new FilterLogic.OddNumbers());

            Assert.AreEqual(expected, actual);
        }
    }
}
