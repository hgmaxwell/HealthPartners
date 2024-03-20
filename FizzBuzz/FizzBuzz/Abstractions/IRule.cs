namespace FizzBuzz.Abstractions;

public interface IRule
{
    bool IsValid(int value);
    string GetResult();
    int Order { get; }
}