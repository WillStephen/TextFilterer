namespace TextFilterer.Filters;

/// <summary>
/// Removes words from text.
/// </summary>
public interface ITextFilter
{
    /// <summary>Filter parts from the given <paramref name="text"/>.</summary>
    /// <param name="text">The text to filter parts from.</param>
    /// <returns><paramref name="text"/>, but with parts removed.</returns>
    string FilterText(string text);
}