using FluentAssertions;

namespace FizzBuzz.Rules
{
    [TestFixture]
    public class BuzzRuleShould
    {
        private BuzzRule buzzRule;

        [SetUp]
        public void Setup()
        {
            buzzRule = new BuzzRule();
        }

        [Test]
        public void ReturnBuzzAsResult()
        {
            buzzRule.GetResult().Should().Be("Buzz");
        }

        [Test]
        [TestCase(3, ExpectedResult = false)]
        [TestCase(5, ExpectedResult = true)]
        [TestCase(15, ExpectedResult = false)]
        public bool ReturnIsValidForValuesDivisibleByFive(int value)
        {
            return buzzRule.IsValid(value);
        }
    }
}
