using TextFilterer.Outputters;
using TextFilterer.Repositories;

namespace TextFilterer.Filters;

/// <inheritdoc/>
public class FileTextFilter(
    ITextFileRepository textFileRepository,
    ITextFilter textFilter,
    IResultOutputter resultOutputter) : IFileTextFilter
{
    private readonly ITextFileRepository textFileRepository = textFileRepository;
    private readonly ITextFilter textFilterer = textFilter;
    private readonly IResultOutputter resultOutputter = resultOutputter;

    /// <inheritdoc/>
    public async Task FilterAndOutputAsync(string filename)
    {
        await foreach (string line in this.textFileRepository.GetLinesAsync(filename))
        {
            string filteredLine = this.textFilterer.FilterText(line);

            this.resultOutputter.OutputLine(filteredLine);
        }
    }
}
