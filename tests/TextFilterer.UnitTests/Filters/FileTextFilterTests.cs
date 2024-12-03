using Moq;
using TextFilterer.Filters;
using TextFilterer.Outputters;
using TextFilterer.Repositories;

namespace TextFilterer.UnitTests.Filters;

[TestClass]
public class FileTextFilterTests
{
    private const string ExampleFilename = "example.txt";

    private readonly Mock<ITextFileRepository> mockRepository = new();
    private readonly Mock<ITextFilter> mockFilterer = new();
    private readonly Mock<IResultOutputter> mockOutputter = new();
    private readonly FileTextFilter sut;

    public FileTextFilterTests()
    {
        this.sut = new FileTextFilter(
            this.mockRepository.Object,
            this.mockFilterer.Object,
            this.mockOutputter.Object);
    }

    [TestMethod]
    public async Task FilterAndOutputAsync_NoLines_ReturnsEmptyString()
    {
        // Arrange
        this.mockRepository
            .Setup(r => r.GetLinesAsync(ExampleFilename))
            .Returns(Array.Empty<string>().ToAsyncEnumerable());

        // Act
        await this.sut.FilterAndOutputAsync(ExampleFilename);

        // Assert
        this.mockOutputter.VerifyNoOtherCalls();
    }

    [TestMethod]
    public async Task FilterAndOutputAsync_SingleLine_AppliesFilter()
    {
        // Arrange
        string originalLine = "She sells sea shells by the sea shore";
        string filteredLine = "She sells shells by the shore";

        this.mockRepository
            .Setup(r => r.GetLinesAsync(ExampleFilename))
            .Returns(new string[] { originalLine }.ToAsyncEnumerable());

        this.mockFilterer
            .Setup(f => f.FilterText(originalLine))
            .Returns(filteredLine);

        // Act
        await this.sut.FilterAndOutputAsync(ExampleFilename);

        // Assert
        this.mockOutputter.Verify(o => o.OutputLine(filteredLine), Times.Once);
        this.mockOutputter.VerifyNoOtherCalls();
    }

    [TestMethod]
    public async Task FilterAndOutputAsync_MultipleLines_AppliesFilterToEachAndJoins()
    {
        // Arrange
        (string OriginalLine, string FilteredLine)[] lines =
            [
                ("She sells sea shells by the sea shore", "She sells shells by the shore"),
                ("Peter Piper picked a peck of pickled peppers", "Peter Piper picked peppers")
            ];

        this.mockRepository
            .Setup(r => r.GetLinesAsync(ExampleFilename))
            .Returns(lines.Select(l => l.OriginalLine).ToAsyncEnumerable());

        foreach ((string originalLine, string filteredLine) in lines)
        {
            this.mockFilterer
                .Setup(f => f.FilterText(originalLine))
                .Returns(filteredLine);
        }

        // Act
        await this.sut.FilterAndOutputAsync(ExampleFilename);

        // Assert
        this.mockOutputter.Verify();
    }
}
