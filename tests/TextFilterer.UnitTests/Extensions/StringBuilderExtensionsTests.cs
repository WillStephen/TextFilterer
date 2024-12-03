using System.Text;
using TextFilterer.Extensions;

namespace TextFilterer.UnitTests.Extensions;

[TestClass]
public class StringBuilderExtensionsTests
{
    [TestMethod]
    public void AppendWithTrailingSpace_AppendsWithTrailingSpace()
    {
        // Arrange
        string word = "Hello";
        StringBuilder stringBuilder = new();

        // Act
        string result = stringBuilder
            .AppendWithTrailingSpace(word)
            .ToString();

        // Assert
        Assert.AreEqual(word + ' ', result);
    }
}
