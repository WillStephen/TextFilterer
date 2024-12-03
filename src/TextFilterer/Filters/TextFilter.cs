using System.Text;
using System.Text.RegularExpressions;
using TextFilterer.Extensions;
using TextFilterer.TextMatchers;

namespace TextFilterer.Filters;

/// <inheritdoc/>
/// <summary>
/// Create a new instance of the <see cref="TextFilterer"/> class.
/// </summary>
/// <param name="textMatchers">A set of matchers used to filter words out.</param>
public partial class TextFilter(IEnumerable<ITextMatcher> textMatchers) : ITextFilter
{
    private readonly IReadOnlyCollection<ITextMatcher> textMatchers = textMatchers.ToList();

    /// <summary>
    /// A cache of words that have already been checked. The key is the word itself,
    /// and the value is a <see cref="bool"/> representing whether the word should be removed from the result.
    /// </summary>
    private readonly Dictionary<string, bool> filteredWords = [];

    /// <inheritdoc/>
    /// <remarks>
    /// Punctuation marks will be preserved in the result.
    /// For example, if <paramref name="text"/> is <c>The Cat, in the Hat</c>,
    /// and the word <c>Cat</c> is filtered out, the result will be <c>The , in the Hat</c>.
    /// </remarks>
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
                    stringBuilder.AppendWithTrailingSpace(part);
                }

                continue;
            }

            if (this.textMatchers.Any(tm => tm.Matches(part)))
            {
                this.filteredWords[part] = true;
                continue;
            }

            this.filteredWords[part] = false;
            stringBuilder.AppendWithTrailingSpace(part);
        }

        // remove the final trailing space before returning
        return stringBuilder.ToString().TrimEnd();
    }

    /// <summary>
    /// Split a string by spaces and punctuation, preserving the punctuation marks as individual strings,
    /// but removing the whitespace parts.
    /// </summary>
    private static string[] SplitToParts(string text)
    {
        return NonWordsRegex()
            .Split(text)
            .Where(str => !string.IsNullOrWhiteSpace(str))
            .ToArray();
    }

    /// <summary>
    /// Matches characters that are not part of words - whitespace, punctuation, etc.
    /// </summary>
    [GeneratedRegex(pattern: @"([^a-zA-Z0-9])")]
    private static partial Regex NonWordsRegex();
}
