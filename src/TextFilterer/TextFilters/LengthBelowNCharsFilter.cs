namespace TextFilterer.TextFilters;

public class LengthBelowNCharsFilter : ITextFilter
{
    private readonly int numberOfChars;

    public LengthBelowNCharsFilter(int numberOfChars)
    {
        if (numberOfChars <= 0)
        {
            throw new ArgumentException("The value must be greater than zero.", nameof(numberOfChars));
        }

        this.numberOfChars = numberOfChars;
    }

    public bool ShouldFilter(string text) => text.Length < this.numberOfChars;
}
