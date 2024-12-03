using TextFilterer;
using TextFilterer.TextFilters;

Filterer textFilterer = new Filterer(
    [
        new VowelInMiddleFilter(),
        new LengthBelowNCharsFilter(3),
        new TextContainsSubstringFilter("t", StringComparison.OrdinalIgnoreCase)
    ]);

string filteredText = textFilterer.FilterText("The cat sat on the mat");
Console.WriteLine(filteredText);