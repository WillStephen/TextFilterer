using TextFilterer.TextFilters;

namespace TextFilterer.UnitTests.TextFilters;

[TestClass]
public class VowelInMiddleFilterTests
{
    private readonly VowelInMiddleFilter sut = new();

    [TestMethod]
    public void ShouldFilter_EmptyString_ReturnsFalse()
    {
        // Act
        bool result = this.sut.ShouldFilter(string.Empty);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [DataRow("d")]
    [DataRow(" ")]
    [DataRow("?")]
    [DataRow("Practice")]
    [DataRow("菠萝")]
    public void ShouldFilter_StringWithoutVowelsInMiddle_ReturnsFalse(string text)
    {
        // Act
        bool result = this.sut.ShouldFilter(text);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [DataRow("Cat")]
    [DataRow("CAT")]
    [DataRow("Mouse")]
    [DataRow("MOUSE")]
    [DataRow("Pig")]
    [DataRow("PIG")]
    [DataRow("Cow")]
    [DataRow("COW")]
    [DataRow("Bug")]
    [DataRow("BUG")]
    public void ShouldFilter_OddLengthStringWithVowelInMiddle_ReturnsTrue(string text)
    {
        // Act
        bool result = this.sut.ShouldFilter(text);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [DataRow("Aquarium")]
    [DataRow("AQUARIUM")]
    [DataRow("Strength")]
    [DataRow("STRENGTH")]
    [DataRow("Distribute")]
    [DataRow("DISTRIBUTE")]
    [DataRow("Favour")]
    [DataRow("FAVOUR")]
    [DataRow("Rung")]
    [DataRow("RUNG")]
    public void ShouldFilter_EvenLengthStringWithVowelInMiddle_ReturnsTrue(string text)
    {
        // Act
        bool result = this.sut.ShouldFilter(text);

        // Assert
        Assert.IsTrue(result);
    }
}
