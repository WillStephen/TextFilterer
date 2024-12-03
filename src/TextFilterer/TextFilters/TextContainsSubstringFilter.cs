namespace TextFilterer.TextFilters;

public class TextContainsSubstringFilter : ITextFilter
{
    private readonly string substring;
    private readonly StringComparison comparisonType;

    public TextContainsSubstringFilter(
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

    public bool ShouldFilter(string text) => text.Contains(this.substring, this.comparisonType);
}
