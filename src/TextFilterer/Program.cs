using TextFilterer;
using TextFilterer.TextMatchers;

Filterer textFilterer = new Filterer(
    [
        new VowelInMiddleMatcher(),
        new LengthBelowNCharsMatcher(3),
        new TextContainsSubstringMatcher("t", StringComparison.OrdinalIgnoreCase)
    ]);

string filteredText = textFilterer.FilterText("The cat sat on the mat");
Console.WriteLine(filteredText);