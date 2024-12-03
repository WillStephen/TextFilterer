using TextFilterer.TextMatchers;

namespace TextFilterer.UnitTests.TextMatchers;

[TestClass]
public class WordContainsSubstringMatcherTests
{
    [TestMethod]
    public void Constructor_EmptySubstring_Throws()
    {
        // Act + Assert
        ArgumentException exception = Assert.ThrowsException<ArgumentException>(
            () => new TextContainsSubstringMatcher(string.Empty));
    }

    [TestMethod]
    [DataRow("DEF")]
    [DataRow("CDEF")]
    [DataRow("DEFG")]
    [DataRow("BCDEFGH")]
    public void Matches_TextContainsSubstringWithSameCase_ReturnsTrue(string text)
    {
        // Arrange
        TextContainsSubstringMatcher sut = new("DEF");

        // Act
        bool result = sut.Matches(text);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Matches_TextDoesNotContainSubstring_ReturnsTrue()
    {
        // Arrange
        TextContainsSubstringMatcher sut = new("Sun");

        // Act
        bool result = sut.Matches("Moon");

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void Matches_CaseDiffersAndComparisonTypeNotSpecified_ReturnsTrue()
    {
        // Arrange
        // here we don't provide a comparison type to the constructor, so it will use the default
        TextContainsSubstringMatcher sut = new("DeF");

        // Act
        bool result = sut.Matches("ABCDEFG");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Matches_CaseDiffersAndComparisonTypeCaseSensitive_ReturnsFalse()
    {
        // Arrange
        // this test basically checks that the class respects the comparisonType arg
        // no need to exhaustively check that it respects every possible value of comparisonType
        TextContainsSubstringMatcher sut = new("DeF", StringComparison.Ordinal);

        // Act
        bool result = sut.Matches("ABCDEFG");

        // Assert
        Assert.IsFalse(result);
    }
}
