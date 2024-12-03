﻿using System.Text;
using TextFilterer.TextFilters;

namespace TextFilterer;

public class Filterer(IEnumerable<ITextFilter> textFilters) : ITextFilterer
{
    private readonly IReadOnlyCollection<ITextFilter> textFilters = textFilters.ToList();

    public string FilterText(string text)
    {
        StringBuilder stringBuilder = new();

        string[] parts = SplitToParts(text);

        foreach (string part in parts)
        {
            if (this.textFilters.Any(tm => tm.ShouldFilter(part)))
            {
                continue;
            }

            stringBuilder
                .Append(part)
                .Append(' ');
        }

        // remove the final trailing space before returning
        return stringBuilder.ToString().TrimEnd();
    }

    private static string[] SplitToParts(string text)
    {
        return text
            .Split(' ')
            .ToArray();
    }
}