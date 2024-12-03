using System.Text;

namespace TextFilterer.Extensions;

/// <summary>
/// A collection of extensions for the <see cref="StringBuilder"/> class.
/// </summary>
public static class StringBuilderExtensions
{
    /// <summary>
    /// Append <paramref name="value"/>, followed by a trailing space.
    /// </summary>
    public static StringBuilder AppendWithTrailingSpace(this StringBuilder stringBuilder, string? value)
    {
        return stringBuilder
            .Append(value)
            .Append(' ');
    }
}
