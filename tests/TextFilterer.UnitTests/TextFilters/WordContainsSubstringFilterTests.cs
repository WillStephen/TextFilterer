using TextFilterer.TextFilters;

namespace TextFilterer.UnitTests.TextFilters;

[TestClass]
public class WordContainsSubstringFilterTests
{
    [TestMethod]
    public void Constructor_EmptySubstring_Throws()
    {
        // Act + Assert
        ArgumentException exception = Assert.ThrowsException<ArgumentException>(
            () => new TextContainsSubstringFilter(string.Empty));
    }

    [TestMethod]
    [DataRow("DEF")]
    [DataRow("CDEF")]
    [DataRow("DEFG")]
    [DataRow("BCDEFGH")]
    public void ShouldFilter_TextContainsSubstringWithSameCase_ReturnsTrue(string text)
    {
        // Arrange
        TextContainsSubstringFilter sut = new("DEF");

        // Act
        bool result = sut.ShouldFilter(text);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ShouldFilter_TextDoesNotContainSubstring_ReturnsTrue()
    {
        // Arrange
        TextContainsSubstringFilter sut = new("Sun");

        // Act
        bool result = sut.ShouldFilter("Moon");

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ShouldFilter_CaseDiffersAndComparisonTypeNotSpecified_ReturnsTrue()
    {
        // Arrange
        // here we don't provide a comparison type to the constructor, so it will use the default
        TextContainsSubstringFilter sut = new("DeF");

        // Act
        bool result = sut.ShouldFilter("ABCDEFG");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ShouldFilter_CaseDiffersAndComparisonTypeCaseSensitive_ReturnsFalse()
    {
        // Arrange
        // this test basically checks that the class respects the comparisonType arg
        // no need to exhaustively check that it respects every possible value of comparisonType
        TextContainsSubstringFilter sut = new("DeF", StringComparison.Ordinal);

        // Act
        bool result = sut.ShouldFilter("ABCDEFG");

        // Assert
        Assert.IsFalse(result);
    }
}
