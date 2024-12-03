using TextFilterer.TextFilters;

namespace TextFilterer.UnitTests.TextFilters;

[TestClass]
public class LengthBelowNCharsFilterTests
{
    [TestMethod]
    [DataRow(0)]
    [DataRow(-1)]
    [DataRow(-50000)]
    public void Constructor_NegativeOrZeroNumberOfChars_Throws(int numberOfChars)
    {
        // Act + Assert
        ArgumentException exception = Assert.ThrowsException<ArgumentException>(
            () => new LengthBelowNCharsFilter(numberOfChars));
    }

    [TestMethod]
    public void ShouldFilter_EmptyStringAndNumberOfCharsOne_ReturnsTrue()
    {
        // Arrange
        LengthBelowNCharsFilter sut = new(numberOfChars: 1);

        // Act
        bool result = sut.ShouldFilter(string.Empty);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ShouldFilter_OneCharacterStringAndNumberOfCharsOne_ReturnsFalse()
    {
        // Arrange
        LengthBelowNCharsFilter sut = new(numberOfChars: 1);

        // Act
        bool result = sut.ShouldFilter(string.Empty);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [DynamicData(nameof(TestStrings))]
    public void ShouldFilter_InputSameLengthAsNumberOfChars_ReturnsFalse(string text)
    {
        // Arrange
        LengthBelowNCharsFilter sut = new(numberOfChars: text.Length);

        // Act
        bool result = sut.ShouldFilter(text);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [DynamicData(nameof(TestStrings))]
    public void ShouldFilter_InputLengthGreaterThanNumberOfChars_ReturnsFalse(string text)
    {
        // Arrange
        LengthBelowNCharsFilter sut = new(numberOfChars: text.Length - 1);

        // Act
        bool result = sut.ShouldFilter(text);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [DynamicData(nameof(TestStrings))]
    public void ShouldFilter_InputLengthLessThanNumberOfChars_ReturnsTrue(string text)
    {
        // Arrange
        LengthBelowNCharsFilter sut = new(numberOfChars: text.Length + 1);

        // Act
        bool result = sut.ShouldFilter(text);

        // Assert
        Assert.IsTrue(result);
    }

    /// <summary>
    /// A set of strings for the tests to use to make sure edge cases are covered.
    /// </summary>
    public static IEnumerable<object[]> TestStrings =>
        [
            ["Mordor"],
            ["?!' #/*&^"],
            ["أرنب"], // check that we can cope with non-Latin characters
            [
                """
                In fact, when I know what is meant by "mamelon" and "ravelin",
                When I can tell at sight a Mauser rifle from a javelin,
                When such affairs as sorties and surprises I'm more wary at,
                And when I know precisely what is meant by "commissariat"
                """ // check that we can cope with longer, multi-line strings
            ]
        ];
}