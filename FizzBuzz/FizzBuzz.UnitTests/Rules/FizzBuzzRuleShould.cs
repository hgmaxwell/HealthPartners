using FluentAssertions;

namespace FizzBuzz.Rules
{
    [TestFixture]
    public class FizzBuzzRuleShould
    {
        private FizzBuzzRule fizzBuzzRule;

        [SetUp]
        public void Setup()
        {
            fizzBuzzRule = new FizzBuzzRule();
        }

        [Test]
        public void ReturnFizzBuzzAsResult()
        {
            fizzBuzzRule.GetResult().Should().Be("FizzBuzz");
        }

        [Test]
        [TestCase(3, ExpectedResult = false)]
        [TestCase(5, ExpectedResult = false)]
        [TestCase(15, ExpectedResult = true)]
        public bool ReturnIsValidForValuesDivisibleByThreeAndFive(int value)
        {
            return fizzBuzzRule.IsValid(value);
        }
    }
}
