using FizzBuzz.Abstractions;

namespace FizzBuzz
{
    public class FizzBuzz : IFizzBuzz
    {
        private readonly List<IRule> rules;

        public FizzBuzz(IEnumerable<IRule> rules)
        {
            this.rules = rules.ToList();
            this.rules.Sort((a, b) => a.Order.CompareTo(b.Order));
        }

        public string GetResultString(int start, int end)
        {
            return string.Empty;
        }
    }
}
