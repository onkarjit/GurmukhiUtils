using System.Text.RegularExpressions;

namespace GurmukhiUtils.Helpers;

internal class DiacriticsSorter
{
    private const string Virama = "੍";
    private const string BelowBaseLetters = "ਹਰਵਟਤਨਚ";
    private const string BelowBasePattern = $"({Virama}[{BelowBaseLetters}])?";

    private static readonly string[] BaseLetterModifiers = { "਼", "ੑ", "ੵ" };
    private static readonly string[] VowelOrder = { "ਿ", "ੇ", "ੈ", "ੋ", "ੌ", "ੁ", "ੂ", "ਾ", "ੀ" };
    private static readonly string[] RemainingModifierOrder = { "ਁ", "ੱ", "ਂ", "ੰ", "ਃ" };

    private static readonly string GeneratedMarks =
        string.Concat(BaseLetterModifiers.Concat(VowelOrder).Concat(RemainingModifierOrder));

    private static readonly string MarkPattern = $"([{GeneratedMarks}]*)";
    private static readonly string RegexMatchPattern = $"{MarkPattern}{BelowBasePattern}{MarkPattern}";
    private static readonly Regex PatternRegex = new(RegexMatchPattern, RegexOptions.Compiled);

    private static readonly string GeneratedMatchOrder = string.Concat(
        BaseLetterModifiers
            .Concat(new[] { Virama })
            .Concat(BelowBaseLetters.ToCharArray().Select(c => c.ToString()))
            .Concat(VowelOrder)
            .Concat(RemainingModifierOrder)
    );

    /// <summary>
    /// Orders the Gurmukhi diacritics in a string according to Unicode standards.
    /// </summary>
    /// <remarks>
    /// Not intended for base letters with multiple subjoined letters.
    /// </remarks>
    /// <param name="input">The string to affect.</param>
    /// <returns>The same string with Gurmukhi diacritics arranged in a sorted manner.</returns>
    /// <example>
    /// <code>
    /// var sorted = SortDiacritics("\u0A41\u0A4B");
    /// Console.WriteLine(sorted == "\u0A4B\u0A41");  // Outputs: true
    /// </code>
    /// </example>
    internal static string SortDiacritics(string input)
    {
        return PatternRegex.Replace(input, match =>
        {
            var matchValue = match.Value;
            if (matchValue.Length <= 1) return matchValue;
            var charArray = matchValue.ToCharArray();
            Array.Sort(charArray, (a, b) => GeneratedMatchOrder.IndexOf(a).CompareTo(GeneratedMatchOrder.IndexOf(b)));
            matchValue = new string(charArray);
            return matchValue;
        });
    }
}