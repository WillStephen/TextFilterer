using TextFilterer.Repositories;

namespace TextFilterer.Filters;

/// <inheritdoc/>
public class FileTextFilter(
    ITextFileRepository textFileRepository,
    ITextFilter textFilter) : IFileTextFilter
{
    private readonly ITextFileRepository textFileRepository = textFileRepository;
    private readonly ITextFilter textFilterer = textFilter;

    /// <inheritdoc/>
    public async Task FilterAndOutputAsync(string filename)
    {
        await foreach (string line in this.textFileRepository.GetLinesAsync(filename))
        {
            string filteredLine = this.textFilterer.FilterText(line);

            Console.WriteLine(filteredLine);
        }
    }
}
