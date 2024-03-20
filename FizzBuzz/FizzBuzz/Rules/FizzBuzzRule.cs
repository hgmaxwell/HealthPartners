using FizzBuzz.Abstractions;

namespace FizzBuzz.Rules
{
    public class FizzBuzzRule : IRule
    {
        public bool IsValid(int value) => value % 15 == 0;
        public string GetResult() => "FizzBuzz";
        public int Order => 1;
    }
}
