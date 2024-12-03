namespace TextFilterer.TextMatchers;

/// <summary>
/// Matches given text.
/// </summary>
public interface ITextMatcher
{
    /// <summary>
    /// Determines whether or not <paramref name="text"/> matches a condition.
    /// </summary>
    /// <param name="text">The input text.</param>
    /// <returns>
    /// <see langword="true"/> when <paramref name="text"/> matches the condition;
    /// <see langword="false"/> otherwise.
    /// </returns>
    bool Matches(string text);
}
