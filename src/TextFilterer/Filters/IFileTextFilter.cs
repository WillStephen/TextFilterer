namespace TextFilterer.Filters;

public interface IFileTextFilter
{
    Task FilterAndOutputAsync(string filename);
}
