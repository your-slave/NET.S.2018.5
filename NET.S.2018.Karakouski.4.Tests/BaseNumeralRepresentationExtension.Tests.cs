using NUnit.Framework;
using NET.S._2018.Karakouski._4;
using System;

namespace NET.S._2018.Karakouski._4.Tests
{
    [TestFixture]
    public class BaseNumeralRepresentationExtensionTests
    {
        /*
"0110111101100001100001010111111" для основания 2 -> 934331071
"01101111011001100001010111111" для основания 2 -> 233620159
"11101101111011001100001010" для основания 2 -> 62370570
"1AeF101" для основания 2 -> ArgumentException
"11111111111111111111111111111111" для основания 2 -> OverflowException
"1AeF101" для основания 16 -> 28242177
"1ACB67" для основания 16 -> 1756007
"SA123" для основания 2 -> ArgumentException
"764241" для основания 8 -> 256161
"764241" для основания 20 -> ArgumentException
"10" для основания 5 -> 5
        */
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
    }
}
