namespace TextFilterer.Repositories;

public interface ITextFileRepository
{
    IAsyncEnumerable<string> GetLinesAsync(string filename);
}
