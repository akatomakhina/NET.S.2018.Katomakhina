using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FilterLogic.Tests
{
    [TestClass]
    public class FilterTests
    {
        Filter listFilter = new Filter();
        public const int FILTER = 3;
        private static int emptyLength = 0;
        private int[] emptyArray = new int[emptyLength];
        int[] array = new int[]{1, -3, 3, 15, -14};

        public TestContext TestContext { get; set; }

        [TestMethod]
        public void FilterDigit_FileFilter()
        {
            int count = 100;
            int[] expected = new int[16];
            int[] actual;
            int[] array = new int[count];

            FileStream fileForFiltered = new FileStream(@"..\..\..\Resources\arrayForFilter.txt", FileMode.Open);
            StreamReader readerWithoutFilter = new StreamReader(fileForFiltered);
            FileStream fileWithFilter = new FileStream(@"..\..\..\Resources\arrayWithFilteredNumber.txt", FileMode.Open);
            StreamReader readerWithFilter = new StreamReader(fileWithFilter);
        
            for (int i = 0; i < count; i++)
            {
                array[i] = Convert.ToInt32(readerWithoutFilter.ReadLine());
            }

            actual = listFilter.FilterDigit(array, FILTER);

            for (int i = 0; i < expected.Length; i++)
            {
                expected[i] = Convert.ToInt32(readerWithFilter.ReadLine());
            }

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void FilterDigit_ArrayFilter()
        {
            int[] expected = new int[]{3, -13, 33, -37, -23, 334};
            int[] actual;
            int[] array = new int[]{1, -90, 3, -15, -13, 1, 100, 33, 0, 2, -37, -51, -23, 14, 334};

            actual = listFilter.FilterDigit(array, FILTER);

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void FilterDigit_ArrayFilterEmptyExpected()
        {
            int[] expected = new int[0];
            int[] actual;
            int[] array = new int[]{1, 2, 22, -90, -44, 18, -88, 81, 19, -42, 20, -51, -25, 14, 554};

            actual = listFilter.FilterDigit(array, FILTER);

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterDigit_ThrowArgumentNullException_Null()
            => listFilter.FilterDigit(null, FILTER);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterDigit_ThrowArgumentNullException_Empty()
            => listFilter.FilterDigit(emptyArray, FILTER);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterDigit_ThrowArgumentOutOfRangeExceptiony()
            => listFilter.FilterDigit(array, 13);
    }
}
