namespace TextFilterer.Extensions;

/// <summary>
/// A set of helper methods for <see cref="char"/>.
/// </summary>
public static class CharExtensions
{
    private readonly static HashSet<char> vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];

    /// <summary>
    /// Returns a <see cref="bool"/> representing whether or not <paramref name="c"/> is a vowel.
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if <paramref name="c"/> is a vowel; otherwise <see langword="false"/>.</returns>
    public static bool IsVowel(this char c) => vowels.Contains(c);
}
