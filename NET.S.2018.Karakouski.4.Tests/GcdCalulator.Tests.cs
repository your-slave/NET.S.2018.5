using NUnit.Framework;
using NET.S._2018.Karakouski._4;

namespace NET.S._2018.Karakouski._4.Tests
{
    [TestFixture]
    public class GcdCalulatorTests
    {
        [TestCase(2, 3, ExpectedResult = 1)]
        [TestCase(6, 2, ExpectedResult = 2)]
        [TestCase(12, 3, 9, ExpectedResult = 3)]
        [TestCase(36, 12, 3, 9, ExpectedResult = 3)]
        public int EuclidianMethod_PoistiveNumbers_TestCalulations(params int[] args) => GcdCalulator.EuclidGcdCalc(args);

        [TestCase(2, -3, ExpectedResult = 1)]
        [TestCase(-6, 2, ExpectedResult = 2)]
        [TestCase(-12, 3, 9, ExpectedResult = 3)]
        [TestCase(36, -12, -3, 9, ExpectedResult = 3)]
        public int EuclidianMethod_PoistiveAndNegativeNumbers_TestCalulations(params int[] args) => GcdCalulator.EuclidGcdCalc(args);

        [TestCase(2, 3, ExpectedResult = 1)]
        [TestCase(6, 2, ExpectedResult = 2)]
        [TestCase(12, 3, 9, ExpectedResult = 3)]
        [TestCase(36, 12, 3, 9, ExpectedResult = 3)]
        public int BinaryMethod_PoistiveNumbers_TestCalulations(params int[] args) => GcdCalulator.BinaryGcdCalc(args);

        [TestCase(2, -3, ExpectedResult = 1)]
        [TestCase(-6, 2, ExpectedResult = 2)]
        [TestCase(-12, 3, 9, ExpectedResult = 3)]
        [TestCase(36, -12, -3, 9, ExpectedResult = 3)]
        public int BinaryMethod_PoistiveAndNegativeNumbers_TestCalulations(params int[] args) => GcdCalulator.BinaryGcdCalc(args);

    }
}
