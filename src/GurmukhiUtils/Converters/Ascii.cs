using System.Text;
using System.Text.RegularExpressions;
using GurmukhiUtils.Replacements;
using GurmukhiUtils.Translations;

namespace GurmukhiUtils.Converters;

internal partial class Ascii
{
    // Warnings
    private const string AboveVowelMarks = "ੇੈੋੌ";
    private const string BelowVowelMarks = "ੁੂ";
    
    private const string AsciiBaseLetters = @"AeshkKgG\|cCjJ\\tTfFxqQdDnpPbBmXrlvVSz^&ZLÎïî";
    private const string AsciiModifiers = "æ@´ÚwIuUyYoO`MNRÍHç†œ˜¨®µˆW~¤Ï";
    private const string AsciiBelowBaseLetters = "RÍHç†œ˜´@";
    private const string CenterStrokeLetters = "nT";
    private const string AsciiNonAboveModifiers = "æ@´ÚwuURÍHç†œ˜ü¨®Ï";

    private const string AboveVowelCheckPattern = $"[ਾ{AboveVowelMarks}][ਾ{AboveVowelMarks}]";
    private const string BelowVowelCheckPattern = $"[ਾ{BelowVowelMarks}][ਾ{BelowVowelMarks}]";
    private const string SihariPattern = $"([{AsciiBaseLetters}][{AsciiModifiers}]*)i([{AsciiModifiers}]*)";
    private const string BelowVowelPattern = $"([{AsciiBelowBaseLetters}][{AsciiModifiers}]*)u([{AsciiModifiers}]*)";
    private const string CenterStrokePattern = $"([{CenterStrokeLetters}][{AsciiModifiers}]*)M([{AsciiModifiers}]*)";
    private const string NasalizationPatternN = $"([{AsciiBaseLetters}][{AsciiNonAboveModifiers}]*)N([{AsciiNonAboveModifiers}]*)";
    private const string NasalizationPatternTilde = $"([{AsciiBaseLetters}][{AsciiNonAboveModifiers}]*)~([{AsciiNonAboveModifiers}]*)";
    
    private static readonly Regex BelowVowelRegexU = new(BelowVowelRegex()
        .ToString()
        .Replace("u", "U"), 
        RegexOptions.Compiled);
    
    [GeneratedRegex(AboveVowelCheckPattern)]
    private static partial Regex AboveVowelCheckRegex();
    
    [GeneratedRegex(BelowVowelCheckPattern)]
    private static partial Regex BelowVowelCheckRegex();

    [GeneratedRegex(SihariPattern)]
    private static partial Regex SihariRegex();

    [GeneratedRegex(BelowVowelPattern)]
    private static partial Regex BelowVowelRegex();

    [GeneratedRegex(CenterStrokePattern)]
    private static partial Regex CenterStrokeRegex();

    [GeneratedRegex(NasalizationPatternN)]
    private static partial Regex NasalizationRegexN();

    [GeneratedRegex(NasalizationPatternTilde)]
    private static partial Regex NasalizationRegexTilde();
    
    /// <summary>
    /// Converts Gurmukhi to ASCII for Open Gurbani Akhar font.
    /// Open Gurbani Akhar is the only font that can fully render the Shabad OS Database. Historically, every other ASCII font has been insufficiently capable.
    /// </summary>
    /// <param name="input">The string to affect.</param>
    /// <returns>A string whose Gurmukhi is converted to an ascii font format.</returns>
    internal static string Convert(string input)
    {
        var sb = new StringBuilder(Unicode.UnicodeNormalize(input));
        
        var checks = new Dictionary<Regex, string>
        {
            { AboveVowelCheckRegex(), "Incorrect vowel syntax (above vowel)" },
            { BelowVowelCheckRegex(), "Incorrect vowel syntax (below vowel)" },
        };

        foreach (var pair in checks)
        {
            if (pair.Key.IsMatch(sb.ToString()))
            {
                throw new Exception(pair.Value);
            }
        }

        foreach (var pair in AsciiReplacement.AsciiReplacements)
        {
            sb.Replace(pair.Key, pair.Value);
        }

        foreach (var pair in Translation.AsciiTranslation)
        {
            sb.Replace(pair.Key, pair.Value);
        }

        // Re-arrange sihari
        sb = new StringBuilder(SihariRegex().Replace(sb.ToString(), "i$1$2"));

        var belowVowelMappings = new Dictionary<string, string>
        {
            { "u", "ü" },
            { "U", "¨" }
        };

        foreach (var pair in belowVowelMappings)
        {
            var currentRegex = pair.Key == "u"
                ? BelowVowelRegex()
                : BelowVowelRegexU;
            sb = new StringBuilder(currentRegex.Replace(sb.ToString(), $"$1{pair.Value}$2"));
        }

        // Fix center-stroke + tippi positioning
        sb = new StringBuilder(CenterStrokeRegex().Replace(sb.ToString(), "$1µ$2"));

        var nasalizationMappings = new Dictionary<string, string>
        {
            { "N", "ˆ" },
            { "~", "`" }
        };

        // Fix positioning of bindi/tippi when it is the only above-base-form
        foreach (var pair in nasalizationMappings)
        {
            var currentRegexN = pair.Key == "N" ? NasalizationRegexN() : NasalizationRegexTilde();
            sb = new StringBuilder(currentRegexN.Replace(sb.ToString(), $"$1{pair.Value}$2"));
        }

        foreach (var pair in AsciiReplacement.AsciiComboReplacements)
        {
            sb.Replace(pair.Key, pair.Value);
        }

        return sb.ToString();
    }
}