using System.Text;
using TextFilterer.TextMatchers;

namespace TextFilterer.Filters;

public class TextFilter(IEnumerable<ITextMatcher> textMatchers) : ITextFilter
{
    private readonly IReadOnlyCollection<ITextMatcher> textMatchers = textMatchers.ToList();

    private readonly Dictionary<string, bool> filteredWords = [];

    public string FilterText(string text)
    {
        StringBuilder stringBuilder = new();

        string[] parts = SplitToParts(text);

        foreach (string part in parts)
        {
            if (this.filteredWords.TryGetValue(part, out bool filteredWord))
            {
                if (!filteredWord)
                {
                    stringBuilder.Append(part).Append(' ');
                }

                continue;
            }

            if (this.textMatchers.Any(tm => tm.Matches(part)))
            {
                this.filteredWords[part] = true;
                continue;
            }

            this.filteredWords[part] = false;
            stringBuilder.Append(part).Append(' ');
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
