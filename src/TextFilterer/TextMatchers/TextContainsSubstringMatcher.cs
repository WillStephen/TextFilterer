namespace TextFilterer.TextMatchers;

public class TextContainsSubstringMatcher : ITextMatcher
{
    private readonly string substring;
    private readonly StringComparison comparisonType;

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

    public bool Matches(string text) => text.Contains(this.substring, this.comparisonType);
}
