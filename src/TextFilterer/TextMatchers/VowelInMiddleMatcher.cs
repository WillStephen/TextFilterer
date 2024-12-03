namespace TextFilterer.TextMatchers;

/// <inheritdoc/>
public class VowelInMiddleMatcher : ITextMatcher
{
    private readonly static char[] vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];

    /// <summary>
    /// Determines whether or not the input <paramref name="text"/> contains a vowel in the middle.
    /// </summary>
    /// <remarks>
    /// If <paramref name="text"/> has an odd number of characters, we only look at the character 
    /// exactly in the middle - e.g. <c>d</c> in <c>odd</c>.
    /// If <paramref name="text"/> has an even number of characters, we check the two innermost
    /// characters, e.g. <c>ve</c> in <c>even</c>.
    /// </remarks>
    /// <inheritdoc/>
    public bool Matches(string text)
    {
        if (text.Length == 0)
        {
            return false;
        }

        IEnumerable<char> middleChars = GetMiddleOfString(text);

        return middleChars.Any(c => IsVowel(c));
    }

    private static IEnumerable<char> GetMiddleOfString(string text)
    {
        // if the length of the string is even, this index will actually be for the character immediately
        // to the right of the centre of the string (i.e. 't' in 'centre'),
        // which is why we also grab the character before it ('n', in the that example) in that case
        int indexOfMiddleChar = text.Length / 2;

        yield return text[indexOfMiddleChar];

        if (text.Length % 2 == 0)
        {
            yield return text[indexOfMiddleChar - 1];
        }
    }

    public static bool IsVowel(char c) => vowels.Contains(c);
}
