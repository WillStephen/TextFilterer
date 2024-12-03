namespace TextFilterer.Outputters;

/// <summary>
/// An outputter to store or display a filtered result.
/// </summary>
public interface IResultOutputter
{
    /// <summary>
    /// Outputs <paramref name="filteredResult"/> to an external interface.
    /// </summary>
    /// <param name="filteredResult">The filtered text to output.</param>
    void OutputLine(string filteredResult);
}