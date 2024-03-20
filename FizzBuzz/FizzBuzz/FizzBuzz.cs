using FizzBuzz.Abstractions;
using System.Text;

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
            StringBuilder sb = new StringBuilder();

            for (int i = start; i <= end; i++)
            {
                string? result = null;

                foreach (var rule in rules)
                {
                    if (rule.IsValid(i))
                    {
                        result = rule.GetResult();
                        break;
                    }
                }

                sb.AppendLine(result ?? i.ToString());
            }

            return sb.ToString();
        }
    }
}
