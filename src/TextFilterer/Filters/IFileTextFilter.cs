namespace TextFilterer.Filters;

/// <summary>
/// Filters text from files.
/// </summary>
public interface IFileTextFilter
{
    /// <summary>
    /// Filters the contents of the file <paramref name="filename"/> and outputs the results.
    /// </summary>
    /// <param name="filename">The path to the file.</param>
    Task FilterAndOutputAsync(string filename);
}
