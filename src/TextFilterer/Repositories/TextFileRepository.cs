namespace TextFilterer.Repositories;

/// <summary>
/// Reads text from files.
/// </summary>
public class TextFileRepository : ITextFileRepository
{
    /// <summary>
    /// Asynchronously read the lines from the file at the path <paramref name="filename"/>.
    /// </summary>
    /// <param name="filename">The path of the file.</param>
    public async IAsyncEnumerable<string> GetLinesAsync(string filename)
    {
        using StreamReader reader = File.OpenText(filename);

        while (!reader.EndOfStream)
        {
            string? line = await reader.ReadLineAsync();

            if (line is not null)
            {
                yield return line;
            }
        }
    }
}
