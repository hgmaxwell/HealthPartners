using FizzBuzz.Abstractions;

namespace FizzBuzz.Rules
{
    public class FizzRule : IRule
    {
        public bool IsValid(int value) => value % 3 == 0;
        public string GetResult() => "Fizz";
        public int Order => 2;
    }
}
