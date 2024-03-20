using FluentAssertions;

namespace FizzBuzz.Rules
{
    [TestFixture]
    public class FizzRuleShould
    {
        private FizzRule fizzRule;

        [SetUp]
        public void Setup()
        {
            fizzRule = new FizzRule();
        }

        [Test]
        public void ReturnFizzAsResult()
        {
            fizzRule.GetResult().Should().Be("Fizz");
        }

        [Test]
        [TestCase(3, ExpectedResult = true)]
        [TestCase(5, ExpectedResult = false)]
        [TestCase(15, ExpectedResult = true)]
        public bool ReturnIsValidForValuesDivisibleByThree(int value)
        {
            return fizzRule.IsValid(value);
        }
    }
}
