using Microsoft.Extensions.DependencyInjection;
using System.CommandLine;
using TextFilterer.Filters;
using TextFilterer.Outputters;
using TextFilterer.Repositories;
using TextFilterer.TextMatchers;

internal class Program
{
    /// <remarks>To run the program, provide an <c>inputFile</c> arg like this: <br/><br/>
    /// <c>--inputFile "Assets/Alice in Wonderland.txt"</c></remarks>
    public static async Task<int> Main(string[] args)
    {
        Option<string> inputFileOption = new(
            name: "--inputFile",
            description: "The file to read and filter.")
        {
            IsRequired = true,
            AllowMultipleArgumentsPerToken = false
        };

        // TODO add an option to preserve/remove punctuation?

        var rootCommand = new RootCommand(description: "A tool to filter out words from text files.");

        rootCommand.AddOption(inputFileOption);
        rootCommand.SetHandler(RunProgram, inputFileOption);

        return await rootCommand.InvokeAsync(args);
    }

    private static async Task RunProgram(string inputFile)
    {
        WriteToConsole.InColour($"Filtering words from '{inputFile}'...", ConsoleColor.DarkGray);

        IServiceProvider serviceProvider = GetServiceProvider();

        IFileTextFilter fileFilterer = serviceProvider.GetRequiredService<IFileTextFilter>();

        await fileFilterer.FilterAndOutputAsync(inputFile);
    }

    private static ServiceProvider GetServiceProvider()
    {
        ServiceCollection serviceCollection = new();

        serviceCollection.AddTransient<ITextFileRepository, TextFileRepository>();
        serviceCollection.AddTransient<ITextFilter, TextFilter>();
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