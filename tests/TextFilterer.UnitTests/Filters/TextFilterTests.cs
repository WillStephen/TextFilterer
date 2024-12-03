using Moq;
using TextFilterer.Filters;
using TextFilterer.TextMatchers;

namespace TextFilterer.UnitTests.Filterers;

[TestClass]
public class TextFilterTests
{
    [TestMethod]
    public void FilterText_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        TextFilter sut = new(Array.Empty<ITextMatcher>());

        // Act
        string result = sut.FilterText(string.Empty);

        // Assert
        Assert.AreEqual(0, result.Length);
    }

    [TestMethod]
    [DataRow("cat dog rabbit", "rabbit", "cat dog")]
    [DataRow("cat dog rabbit", "cat", "dog rabbit")]
    [DataRow("cat dog rabbit", "dog", "cat rabbit")]
    public void FilterText_MatcherMatchesSingleWord_RemovesWordFromResult(
        string inputText,
        string wordToFilter,
        string expectedResult)
    {
        // Arrange
        ITextMatcher mockMatcher = CreateMockMatcherForString(wordToFilter);

        TextFilter sut = new([mockMatcher]);

        // Act
        string result = sut.FilterText(inputText);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void FilterText_MultipleMatchersMatch_RemovesAllMatchedWords()
    {
        // Arrange
        ITextMatcher mockCatMatcher = CreateMockMatcherForString("cat");
        ITextMatcher mockRabbitMatcher = CreateMockMatcherForString("rabbit");

        TextFilter sut = new([mockCatMatcher, mockRabbitMatcher]);

        // Act
        string result = sut.FilterText("cat dog rabbit");

        // Assert
        Assert.AreEqual("dog", result);
    }

    [TestMethod]
    public void FilterText_MatcherMatchesWordWithMultipleInstances_RemovesAllInstances()
    {
        // Arrange
        ITextMatcher mockCatMatcher = CreateMockMatcherForString("cat");

        TextFilter sut = new([mockCatMatcher]);

        // Act
        string result = sut.FilterText("cat dog cat cat dog cat rabbit");

        // Assert
        Assert.AreEqual("dog dog rabbit", result);
    }

    [TestMethod]
    [DataRow(';')]
    [DataRow('?')]
    [DataRow('!')]
    [DataRow(',')]
    public void FilterText_MatcherMatchesWordBeforePunctuation_RemovesWordAndPreservesPunctuation(char punctuation)
    {
        // Arrange
        ITextMatcher mockMatcher = CreateMockMatcherForString("two");

        TextFilter sut = new([mockMatcher]);

        // Act
        string result = sut.FilterText($"one two{punctuation} three");

        // Assert
        Assert.AreEqual($"one {punctuation} three", result);
    }

    #region Helper methods

    private static ITextMatcher CreateMockMatcherForString(string str)
    {
        return Mock.Of<ITextMatcher>(m
            => m.Matches(It.IsAny<string>()) == false
            && m.Matches(str) == true);
    }

    #endregion Helper methods
}
