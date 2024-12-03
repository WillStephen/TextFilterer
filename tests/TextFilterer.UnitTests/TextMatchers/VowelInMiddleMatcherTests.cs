using TextFilterer.TextMatchers;

namespace TextFilterer.UnitTests.TextMatchers;

[TestClass]
public class VowelInMiddleMatcherTests
{
    private readonly VowelInMiddleMatcher sut = new();

    [TestMethod]
    public void Matches_EmptyString_ReturnsFalse()
    {
        // Act
        bool result = this.sut.Matches(string.Empty);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [DataRow("d")]
    [DataRow(" ")]
    [DataRow("?")]
    [DataRow("Practice")]
    [DataRow("菠萝")]
    public void Matches_StringWithoutVowelsInMiddle_ReturnsFalse(string text)
    {
        // Act
        bool result = this.sut.Matches(text);

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
    public void Matches_OddLengthStringWithVowelInMiddle_ReturnsTrue(string text)
    {
        // Act
        bool result = this.sut.Matches(text);

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
    public void Matches_EvenLengthStringWithVowelInMiddle_ReturnsTrue(string text)
    {
        // Act
        bool result = this.sut.Matches(text);

        // Assert
        Assert.IsTrue(result);
    }
}
