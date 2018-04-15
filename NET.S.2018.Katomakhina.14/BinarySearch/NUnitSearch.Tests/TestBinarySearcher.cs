using NUnit.Framework;
using System;
using BinarySearchLogic;

namespace NUnitSearch.Tests
{
    [TestFixture]
    public class TestBinarySearcher
    {
        [TestCase(new[] { 1, 12, 23, 29, 30, 44, 56, 68, 90, 123 }, 29, ExpectedResult = 3)]
        [TestCase(new[] { 1, 12, 23, 29, 30, 44, 56, 68, 90, 123 }, 1, ExpectedResult = 0)]
        [TestCase(new[] { 1, 12, 23, 29, 30, 44, 56, 68, 90, 123 }, 56, ExpectedResult = 6)]
        [TestCase(new[] { 1, 12, 23, 29, 30, 44, 56, 68, 90, 123 }, 44, ExpectedResult = 5)]
        [TestCase(new[] { 1, 12, 23, 29, 30, 44, 56, 68, 90, 123 }, 23, ExpectedResult = 2)]
        [TestCase(new[] { 1, 12, 23, 29, 30, 44, 56, 68, 90, 123 }, 3, ExpectedResult = -1)]

        [TestCase(new[] { 1, 12, 23, 29, 30, 44, 56, 68, 90, 123 }, 12, ExpectedResult = 1)]
        [TestCase(new[] { 1, 12, 23, 29, 30, 44, 56, 68, 90, 123 }, 30, ExpectedResult = 4)]

        public static int BinarySearch_Array_GetDefaultComparison_Index(int[] arr, int value)
        {
            return BinarySearcher.BinarySearch(arr, value);
        }

        [TestCase(new[] { 1, -4, 6, -9, 12, -45, 65 }, -9, ExpectedResult = 3)]
        public static int BinarySearch_Array_Comparison_Index(int[] arr, int value)
        {
            return BinarySearcher.BinarySearch(arr, value, (i, i1) => Math.Abs(i) - Math.Abs(i1));
        }

        [TestCase(new[] { "Cat", "Dog", "NotCat", "NotDog", "Animal" }, "NotCat", ExpectedResult = 2)]
        public static int BinarySearch_Array_Comparison_Index(string[] arr, string value)
        {
            return BinarySearcher.BinarySearch(arr, value, (i, i1) => i.Length - i1.Length);
        }
    }
}
