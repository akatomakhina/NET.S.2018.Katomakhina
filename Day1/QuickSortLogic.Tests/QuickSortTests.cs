using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuickSortLogic.Tests
{
    [TestClass]
    public class QuickSortTests
    {
        private int count = 50;
        private static int emptyLength = 0;
        QuickSort quick = new QuickSort();
        private int[] emptyArray = new int[emptyLength];

        [TestMethod]
        public void SortByQuickSorting_SortingWithArrayFromAFile()
        {
            int[] expected = new int[count];
            int[] actual = new int[count];

            FileStream fileForSorting = new FileStream(@"..\..\..\Resources\arrayWithoutSorting.txt", FileMode.Open);
            StreamReader readerWithoutSorting = new StreamReader(fileForSorting);
            FileStream sortedFile = new FileStream(@"..\..\..\Resources\arrayWithSorting.txt", FileMode.Open);
            StreamReader readerWithSorting = new StreamReader(sortedFile);

            for (int i = 0; i < count; i++)
            {
                actual[i] = Convert.ToInt32(readerWithSorting.ReadLine());
                expected[i] = Convert.ToInt32(readerWithoutSorting.ReadLine());
            }
            readerWithSorting.Close();
            readerWithoutSorting.Close();

            quick.SortByQuickSorting(expected);

            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void SortByQuickSorting_SortingArray()
        {
            int count = 10;
            int[] expected = new int[count];
            int[] actual = new int[count];

            actual[0] = 1;
            actual[1] = -90;
            actual[2] = 3;
            actual[3] = -15;
            actual[4] = 14;
            actual[5] = 1;
            actual[6] = -100;
            actual[7] = 1000;
            actual[8] = 0;
            actual[9] = 2;

            quick.SortByQuickSorting(actual);

            expected[0] = -100;
            expected[1] = -90;
            expected[2] = -15;
            expected[3] = 0;
            expected[4] = 1;
            expected[5] = 1;
            expected[6] = 2;
            expected[7] = 3;
            expected[8] = 14;
            expected[9] = 1000;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortByQuickSorting_SortingRandomArray()
        {
            int count = 1000;
            int[] expected = new int[count];
            int[] actual = new int[count];
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                expected[i] = random.Next(-1000, 1001);
            }

            actual = expected;

            Array.Sort(expected);

            quick.SortByQuickSorting(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortByQuickSorting_ThrowArgumentNullException_Null()
            => quick.SortByQuickSorting(null);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortByQuickSorting_ThrowArgumentNullException_Empty()
            => quick.SortByQuickSorting(emptyArray);
    }
}
