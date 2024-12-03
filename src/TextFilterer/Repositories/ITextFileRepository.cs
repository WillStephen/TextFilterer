namespace TextFilterer.Repositories;

/// <inheritdoc/>
public interface ITextFileRepository
{
    /// <inheritdoc/>
    IAsyncEnumerable<string> GetLinesAsync(string filename);
}
