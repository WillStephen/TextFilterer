using TextFilterer.Extensions;

namespace TextFilterer.UnitTests.Extensions;

[TestClass]
public class CharExtensionsTests
{
    [TestMethod]
    [DataRow('v')]
    [DataRow('H')]
    public void IsVowel_Consonant_ReturnsFalse(char character)
    {
        // Act
        bool result = character.IsVowel();

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [DataRow('a')]
    [DataRow('A')]
    [DataRow('e')]
    [DataRow('E')]
    [DataRow('i')]
    [DataRow('I')]
    [DataRow('o')]
    [DataRow('O')]
    [DataRow('u')]
    [DataRow('U')]
    public void IsVowel_Vowel_ReturnsTrue(char character)
    {
        // Act
        bool result = character.IsVowel();

        // Assert
        Assert.IsTrue(result);
    }
}
