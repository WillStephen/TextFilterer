using Microsoft.Extensions.DependencyInjection;
using TextFilterer.Filters;
using TextFilterer.Outputters;
using TextFilterer.Repositories;
using TextFilterer.TextMatchers;

internal class Program
{
    public static async Task Main(string[] args)
    {
        IServiceProvider serviceProvider = GetServiceProvider();

        IFileTextFilter fileTextFilter = serviceProvider.GetRequiredService<IFileTextFilter>();

        await fileTextFilter.FilterAndOutputAsync("Assets/AliceInWonderland.txt");
    }

    private static ServiceProvider GetServiceProvider()
    {
        ServiceCollection serviceCollection = new();

        serviceCollection.AddTransient<ITextFilter, TextFilter>();
        serviceCollection.AddTransient<ITextFileRepository, TextFileRepository>();
        serviceCollection.AddTransient<IFileTextFilter, FileTextFilter>();
        serviceCollection.AddTransient<IResultOutputter, ConsoleResultOutputter>();

        serviceCollection.AddTransient<ITextMatcher, VowelInMiddleMatcher>();
        serviceCollection.AddTransient<ITextMatcher>(
            sp => new TextContainsSubstringMatcher(substring: "t", StringComparison.OrdinalIgnoreCase));
        serviceCollection.AddTransient<ITextMatcher>(
            sp => new LengthBelowNCharsMatcher(numberOfChars: 3));

        return serviceCollection.BuildServiceProvider();
    }
}