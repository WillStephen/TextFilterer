namespace TextFilterer.TextMatchers;

public class VowelInMiddleMatcher : ITextMatcher
{
    private readonly static char[] vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];

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
        int indexOfMiddleChar = text.Length / 2;

        yield return text[indexOfMiddleChar];

        if (text.Length % 2 == 0)
        {
            yield return text[indexOfMiddleChar - 1];
        }
    }

    public static bool IsVowel(char c) => vowels.Contains(c);
}
