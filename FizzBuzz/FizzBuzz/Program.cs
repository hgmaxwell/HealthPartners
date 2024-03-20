using FizzBuzz.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var serviceProvider = ConfigureServices();

var fizzBuzz = serviceProvider.GetService<IFizzBuzz>();
var result = fizzBuzz?.GetResultString(1, 100);

Console.Write(result);

IServiceProvider ConfigureServices()
{
    var services = new ServiceCollection();

    // Use reflection to get all types that implement IRule
    var ruleTypes = Assembly.GetExecutingAssembly().GetTypes()
        .Where(t => t.GetInterfaces().Contains(typeof(IRule)) && !t.IsInterface);

    // Register all rule types with the DI container
    foreach (var ruleType in ruleTypes)
    {
        services.AddTransient(typeof(IRule), ruleType);
    }

    services.AddTransient<IFizzBuzz, FizzBuzz.FizzBuzz>();

    return services.BuildServiceProvider();
}