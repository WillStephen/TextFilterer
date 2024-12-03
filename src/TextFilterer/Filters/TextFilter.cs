using System.Text;
using TextFilterer.TextMatchers;

namespace TextFilterer.Filters;

public class TextFilter(IEnumerable<ITextMatcher> textFilters) : ITextFilter
{
    private readonly IReadOnlyCollection<ITextMatcher> textFilters = textFilters.ToList();

    public string FilterText(string text)
    {
        StringBuilder stringBuilder = new();

        string[] parts = SplitToParts(text);

        foreach (string part in parts)
        {
            if (this.textFilters.Any(tm => tm.Matches(part)))
            {
                continue;
            }

            stringBuilder
                .Append(part)
                .Append(' ');
        }

        // remove the final trailing space before returning
        return stringBuilder.ToString().TrimEnd();
    }

    private static string[] SplitToParts(string text)
    {
        return text
            .Split(' ')
            .ToArray();
    }
}
