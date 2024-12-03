using Microsoft.Extensions.DependencyInjection;
using TextFilterer.Filters;
using TextFilterer.Repositories;
using TextFilterer.TextMatchers;

internal class Program
{
    public static async Task Main(string[] args)
    {
        IServiceProvider serviceProvider = GetServiceProvider();

        ITextFilter textFilter = serviceProvider.GetRequiredService<ITextFilter>();
        ITextFileRepository textFileRepository = serviceProvider.GetRequiredService<ITextFileRepository>();

        await foreach (string line in textFileRepository.GetLinesAsync("Assets/AliceInWonderland.txt"))
        {
            string filteredLine = textFilter.FilterText(line);
            Console.WriteLine(filteredLine);
        }
    }

    private static ServiceProvider GetServiceProvider()
    {
        ServiceCollection serviceCollection = new();

        serviceCollection.AddTransient<ITextFilter, TextFilter>();
        serviceCollection.AddTransient<ITextFileRepository, TextFileRepository>();

        serviceCollection.AddTransient<ITextMatcher, VowelInMiddleMatcher>();
        serviceCollection.AddTransient<ITextMatcher>(
            sp => new TextContainsSubstringMatcher(substring: "t", StringComparison.OrdinalIgnoreCase));
        serviceCollection.AddTransient<ITextMatcher>(
            sp => new LengthBelowNCharsMatcher(numberOfChars: 3));

        return serviceCollection.BuildServiceProvider();
    }
}