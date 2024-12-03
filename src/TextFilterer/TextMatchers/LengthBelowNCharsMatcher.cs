namespace TextFilterer.TextMatchers;

/// <inheritdoc/>
public class LengthBelowNCharsMatcher : ITextMatcher
{
    private readonly int numberOfChars;

    /// <summary>
    /// Create a new instance of the <see cref="LengthBelowNCharsMatcher"/> class.
    /// </summary>
    /// <param name="numberOfChars">The maximum number of characters in the input strings.</param>
    /// <exception cref="ArgumentException">If <paramref name="numberOfChars"/> less than or equal to 0.</exception>
    public LengthBelowNCharsMatcher(int numberOfChars)
    {
        if (numberOfChars <= 0)
        {
            throw new ArgumentException("The value must be greater than zero.", nameof(numberOfChars));
        }

        this.numberOfChars = numberOfChars;
    }

    /// <summary>
    /// Determines whether or not the number of characters in <paramref name="text"/> is below the configured number.
    /// </summary>
    /// <inheritdoc/>
    public bool Matches(string text) => text.Length < this.numberOfChars;
}
