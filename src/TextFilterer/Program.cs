using Microsoft.Extensions.DependencyInjection;
using TextFilterer.Filters;
using TextFilterer.TextMatchers;

internal class Program
{
    public static void Main(string[] args)
    {
        IServiceProvider serviceProvider = GetServiceProvider();

        ITextFilter textFilter = serviceProvider.GetRequiredService<ITextFilter>();
        string filteredText = textFilter.FilterText("The cat sat on the mat");

        Console.WriteLine(filteredText);
    }

    private static ServiceProvider GetServiceProvider()
    {
        ServiceCollection serviceCollection = new();

        serviceCollection.AddTransient<ITextFilter, TextFilter>();

        serviceCollection.AddTransient<ITextMatcher, VowelInMiddleMatcher>();
        serviceCollection.AddTransient<ITextMatcher>(
            sp => new TextContainsSubstringMatcher(substring: "t", StringComparison.OrdinalIgnoreCase));
        serviceCollection.AddTransient<ITextMatcher>(
            sp => new LengthBelowNCharsMatcher(numberOfChars: 3));

        return serviceCollection.BuildServiceProvider();
    }
}