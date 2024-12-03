namespace TextFilterer.TextMatchers;

/// <inheritdoc/>
public class TextContainsSubstringMatcher : ITextMatcher
{
    private readonly string substring;
    private readonly StringComparison comparisonType;

    /// <summary>
    /// Create a new instance of the <see cref="TextFilterer"/> class.
    /// </summary>
    /// <param name="substring">The substring to search for within the input string.</param>
    /// <param name="comparisonType">
    /// The comparison type used to compare the substring to the input string.
    /// The default is <see cref="StringComparison.OrdinalIgnoreCase"/>.
    /// </param>
    /// <exception cref="ArgumentException"> When <paramref name="substring"/> is an empty string. </exception>
    public TextContainsSubstringMatcher(
        string substring,
        StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
    {
        if (substring.Length == 0)
        {
            throw new ArgumentException("Cannot be an empty string.", nameof(substring));
        }

        this.substring = substring;
        this.comparisonType = comparisonType;
    }

    /// <summary>
    /// Determines whether or not the input <paramref name="text"/> contains the substring used to
    /// construct this object.
    /// </summary>
    /// <inheritdoc/>
    public bool Matches(string text) => text.Contains(this.substring, this.comparisonType);
}
