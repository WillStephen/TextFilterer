namespace TextFilterer.TextFilters;

public interface ITextFilter
{
    bool ShouldFilter(string text);
}
