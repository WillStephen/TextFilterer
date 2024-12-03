namespace TextFilterer.Outputters;

/// <summary>
/// A collection of functions to simplify writing to the console.
/// </summary>
public static class WriteToConsole
{
    /// <summary>
    /// Write <paramref name="text"/> to the <see cref="Console"/> in the colour <paramref name="colour"/>.
    /// </summary>
    public static void InColour(string text, ConsoleColor colour)
    {
        ConsoleColor currentColour = Console.ForegroundColor;

        Console.ForegroundColor = colour;
        Console.WriteLine(text);
        Console.ForegroundColor = currentColour;
    }
}