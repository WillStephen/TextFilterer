namespace TextFilterer.Outputters;

/// <inheritdoc/>
public class ConsoleResultOutputter : IResultOutputter
{
    private const ConsoleColor InfoColour = ConsoleColor.Green;
    private const ConsoleColor ResultTextColour = ConsoleColor.White;

    /// <summary>
    /// Formats and writes the <paramref name="line"/> to the console.
    /// </summary>
    /// <param name="line">The text to print to the console.</param>
    public void OutputLine(string line)
    {
        WriteToConsole.InColour(line, ResultTextColour);
    }
}
