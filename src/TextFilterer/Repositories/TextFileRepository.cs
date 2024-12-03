namespace TextFilterer.Repositories;

public class TextFileRepository : ITextFileRepository
{
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
