using System;
using NUnit.Framework;

namespace StringRepresentationLogic.Tests
{
    [TestFixture]
    public class StringRepresentationConverterTest
    {
        [Test]
        [TestCase("0110111101100001100001010111111", 2, ExpectedResult = 934331071)]
        [TestCase("01101111011001100001010111111", 2, ExpectedResult = 233620159)]
        [TestCase("11101101111011001100001010", 2, ExpectedResult = 62370570)]
        [TestCase("1AeF101", 16, ExpectedResult = 28242177)]
        [TestCase("1ACB67", 16, ExpectedResult = 1756007)]
        [TestCase("764241", 8, ExpectedResult = 256161)]
        [TestCase("10", 5, ExpectedResult = 5)]

        public static long ToDecimalForm_Numbers_Result(string source, int systemIndex)
            => source.ToDecimalForm(new StringRepresentationConverter.Notation(systemIndex));

        [Test]
        [TestCase("1000011101110101", ExpectedResult = 34677)]
        public static long ToDecimalForm_Numbers_Result_WithDefaultBasis(string source)
            => source.ToDecimalForm(new StringRepresentationConverter.Notation());

        [Test]
        [TestCase("1AeF101", 2)]
        [TestCase("SA123", 2)]
        public static void ArgumentException_ToDecimalFormArgumentException(string source, int systemIndex)
            => Assert.Throws<ArgumentException>(() => source.ToDecimalForm(new StringRepresentationConverter.Notation()));

        [Test]
        [TestCase("11111111111111111111111111111111", 2)]
        public static void OverflowException_ToDecimalFormOverflowException(string source, int systemIndex)
            => Assert.Throws<OverflowException>(() => source.ToDecimalForm(new StringRepresentationConverter.Notation()));

        [Test]
        [TestCase("764241", 20)]
        public static void ArgumentOutOfRangeException_ToDecimalFormArgumentException(string source, int systemIndex)
            => Assert.Throws<ArgumentOutOfRangeException>(() => source.ToDecimalForm(new StringRepresentationConverter.Notation()));

        [Test]
        [TestCase(null, 2)]
        public static void ArgumentNullException_ToDecimalFormOverflowException(string source, int systemIndex)
            => Assert.Throws<ArgumentNullException>(() => source.ToDecimalForm(new StringRepresentationConverter.Notation()));

    }
}
