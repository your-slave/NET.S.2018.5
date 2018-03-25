using NUnit.Framework;
using NET.S._2018.Karakouski._4;
using System;

namespace NET.S._2018.Karakouski._4.Tests
{
    [TestFixture]
    public class BaseNumeralRepresentationExtensionTests
    {
        [TestCase("0110111101100001100001010111111", 2, ExpectedResult = "934331071")]
        [TestCase("01101111011001100001010111111", 2, ExpectedResult = "233620159")]
        [TestCase("11101101111011001100001010", 2, ExpectedResult = "62370570")]
        [TestCase("1AeF101", 16, ExpectedResult = "28242177")]
        [TestCase("1ACB67", 16, ExpectedResult = "1756007")]
        [TestCase("764241", 8, ExpectedResult = "256161")]
        [TestCase("10", 5, ExpectedResult = "5")]
        public string Base10Number_NormalInputs_TestCalulations(string number, int nBase) => number.Base10Number(nBase);

        [TestCase("1AeF101", 2)]
        public void Base10Number_StringHavingSymbolsOutOfTheBase_ArgumentException(string number, int nBase)
        {
            Assert.Throws<ArgumentException>(() => number.Base10Number(nBase));
        }

        [TestCase("11111111111111111111111111111111", 2)]
        public void Base10Number_TooBigInputValue_OverflowException(string number, int nBase)
        {
            Assert.Throws<OverflowException>(() => number.Base10Number(nBase));
        }

        [TestCase("SA123", 2)]
        public void Base10Number_InvalidSymbolInTheInputString_ArgumentException(string number, int nBase)
        {
            Assert.Throws<ArgumentException>(() => number.Base10Number(nBase));
        }

        [TestCase("764241", 20)]
        public void Base10Number_UnsupportedBase_ArgumentOutOfRangeException(string number, int nBase)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => number.Base10Number(nBase));
        }

        [TestCase(16.9, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        //[TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        //[TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        //[TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        //[TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        //[TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
        //[TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        public string IEEE754Representation_NormalInputs_TestCalulations(double number) => number.IEEE754Representation();
    }
}
