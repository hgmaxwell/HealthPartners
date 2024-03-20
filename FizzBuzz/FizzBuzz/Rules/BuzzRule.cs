using FizzBuzz.Abstractions;

namespace FizzBuzz.Rules
{
    public class BuzzRule : IRule
    {
        public bool IsValid(int value) => value % 5 == 0;
        public string GetResult() => "Buzz";
        public int Order => 3;
    }
}
