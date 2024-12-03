namespace TextFilterer.TextMatchers;

public class LengthBelowNCharsMatcher : ITextMatcher
{
    private readonly int numberOfChars;

    public LengthBelowNCharsMatcher(int numberOfChars)
    {
        if (numberOfChars <= 0)
        {
            throw new ArgumentException("The value must be greater than zero.", nameof(numberOfChars));
        }

        this.numberOfChars = numberOfChars;
    }

    public bool Matches(string text) => text.Length < this.numberOfChars;
}
