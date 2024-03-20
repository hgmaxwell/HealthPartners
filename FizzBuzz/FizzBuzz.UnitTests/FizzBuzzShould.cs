using FizzBuzz.Abstractions;
using FluentAssertions;
using NSubstitute;

namespace FizzBuzz
{
    public class FizzBuzzShould
    {
        private IFizzBuzz fizzBuzz;
        private IRule fizzRule;
        private IRule buzzRule;
        private IRule fizzBuzzRule;

        [SetUp]
        public void Setup()
        {
            // Create substitutes (mocks) for each rule
            fizzRule = Substitute.For<IRule>();
            fizzRule.IsValid(Arg.Any<int>()).Returns(x => x.Arg<int>() % 3 == 0);
            fizzRule.GetResult().Returns("Fizz");
            fizzRule.Order.Returns(2);

            buzzRule = Substitute.For<IRule>();
            buzzRule.IsValid(Arg.Any<int>()).Returns(x => x.Arg<int>() % 5 == 0);
            buzzRule.GetResult().Returns("Buzz");
            buzzRule.Order.Returns(3);

            fizzBuzzRule = Substitute.For<IRule>();
            fizzBuzzRule.IsValid(Arg.Any<int>()).Returns(x => x.Arg<int>() % 15 == 0);
            fizzBuzzRule.GetResult().Returns("FizzBuzz");
            fizzBuzzRule.Order.Returns(1);

            var rules = new List<IRule> { fizzRule, buzzRule, fizzBuzzRule };

            fizzBuzz = new FizzBuzz(rules);
        }

        [Test]
        public void UseFizzRuleForMultiplesOfThree()
        {
            fizzBuzz.GetResultString(3, 3);

            fizzRule.Received().IsValid(3);
            fizzRule.Received().GetResult();
        }

        [Test]
        public void UseBuzzRuleForMultiplesOfFive()
        {
            fizzBuzz.GetResultString(5, 5);

            buzzRule.Received().IsValid(5);
            buzzRule.Received().GetResult();
        }

        [Test]
        public void UseFizzBuzzRuleForMultiplesOfThreeAndFive()
        {
            fizzBuzz.GetResultString(15, 15);

            fizzBuzzRule.Received().IsValid(15);
            fizzBuzzRule.Received().GetResult();
        }

        [Test]
        public void ExecuteRulesInOrder()
        {
            fizzBuzz.GetResultString(1, 1);

            Received.InOrder(() =>
            {
                fizzBuzzRule.IsValid(1);
                fizzRule.IsValid(1);
                buzzRule.IsValid(1);
            });
        }

        [Test]
        public void ReturnCorrectResultString()
        {
            var expectedResults = new List<string>
            {
                "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz",
                "11", "Fizz", "13", "14", "FizzBuzz", "16", "17", "Fizz", "19", "Buzz",
                "Fizz", "22", "23", "Fizz", "Buzz", "26", "Fizz", "28", "29", "FizzBuzz",
                "31", "32", "Fizz", "34", "Buzz", "Fizz", "37", "38", "Fizz", "Buzz",
                "41", "Fizz", "43", "44", "FizzBuzz", "46", "47", "Fizz", "49", "Buzz",
                "Fizz", "52", "53", "Fizz", "Buzz", "56", "Fizz", "58", "59", "FizzBuzz",
                "61", "62", "Fizz", "64", "Buzz", "Fizz", "67", "68", "Fizz", "Buzz",
                "71", "Fizz", "73", "74", "FizzBuzz", "76", "77", "Fizz", "79", "Buzz",
                "Fizz", "82", "83", "Fizz", "Buzz", "86", "Fizz", "88", "89", "FizzBuzz",
                "91", "92", "Fizz", "94", "Buzz", "Fizz", "97", "98", "Fizz", "Buzz"
            };

            var expectedResultString = string.Join(Environment.NewLine, expectedResults) + Environment.NewLine;

            var result = fizzBuzz.GetResultString(1, 100);

            result.Should().Be(expectedResultString);
        }
    }
}