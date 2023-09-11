using System.Text;
using System.Text.RegularExpressions;
using GurmukhiUtils.Enums;
using GurmukhiUtils.Helpers;
using GurmukhiUtils.Replacements;
using GurmukhiUtils.Translations;

namespace GurmukhiUtils.Converters;

internal static partial class Unicode
{
    // Move ASCII sihari before mapping to unicode
    private const string AsciiBaseLetters = @"\\a-zA-Z\|\^&Îîï";
    private const string AsciiSihariPattern = "(i)([" + AsciiBaseLetters + "])";

    [GeneratedRegex(AsciiSihariPattern)]
    private static partial Regex SihariRegex();

    /// <summary>
    /// Converts any ASCII Gurmukhi characters and sanitizes to unicode gurmukhi.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Converting yayya (ਯ) variants with an open top using the Unicode Consortium standard is considered destructive. 
    /// This function will substitute the original with its shirorekha/top-line equivalent.
    /// </para>
    /// <para>
    /// Many fonts and text shaping engines fail to render half-yayya (੍ਯ) correctly. Regardless of the standard used, 
    /// it is recommended to use the Sant Lipi font mentioned below.
    /// </para>
    /// <para>
    /// The mapping system to use. The default is unicode compliant and can render 99% of the Shabad OS Database. 
    /// The other option "Sant Lipi" is intended for a custom unicode font bearing the same name 
    /// (see: <see href="https://github.com/shabados/SantLipi"/>). Defaults to "Unicode Consortium".
    /// </para>
    /// </remarks>
    /// <param name="input">The string to affect.</param>
    /// <param name="unicodeStandard">The unicode standard to use for conversion.</param>
    /// <returns>A string whose Gurmukhi is normalized to a unicode standard.</returns>
    /// <example>
    /// <code>
    /// var result1 = Convert("123");
    /// Console.WriteLine(result1);  // Outputs: '੧੨੩'
    ///
    /// var result2 = Convert("&lt;&gt; &gt; &lt;");
    /// Console.WriteLine(result2);  // Outputs: 'ੴ ☬ ੴ'
    ///
    /// var result3 = Convert("gurU");
    /// Console.WriteLine(result3);  // Outputs: 'ਗੁਰੂ'
    /// </code>
    /// </example>
    internal static string Convert(string input,
        UnicodeStandards unicodeStandard = UnicodeStandards.UnicodeConsortium)
    {
        // Use compiled regex for frequently used patterns
        input = SihariRegex().Replace(input, "$2$1");

        var sb = new StringBuilder(input);

        // Map any ASCII / Unicode Gurmukhi to Sant Lipi format
        foreach (var replacement in UnicodeReplacement.AsciiToSlReplacements)
        {
            sb.Replace(replacement.Key, replacement.Value);
        }

        foreach (var replacement in UnicodeReplacement.UnicodeToSlReplacements)
        {
            sb.Replace(replacement.Key, replacement.Value);
        }

        // Convert using the ASCII_TO_SL_TRANSLATION dictionary
        foreach (var translation in Translation.AsciiToSlTranslation)
        {
            sb.Replace(translation.Key, translation.Value);
        }

        // Normalize Unicode
        sb = new StringBuilder(UnicodeNormalize(sb.ToString()));

        if (unicodeStandard == UnicodeStandards.UnicodeConsortium)
        {
            foreach (var replacement in UnicodeReplacement.SlToUnicodeReplacements)
            {
                sb.Replace(replacement.Key, replacement.Value);
            }
        }
        
        return sb.ToString();
    }

    /// <summary>
    /// Normalizes Gurmukhi according to Unicode Standards.
    /// </summary>
    /// <param name="input">The string to affect.</param>
    /// <returns>Returns a string containing normalized Gurmukhi.</returns>
    /// <example>
    /// <code>
    /// var result = UnicodeNormalize("Hello ਜੀ");
    /// Console.WriteLine(result);  // Outputs: 'Hello ਜੀ'
    /// </code>
    /// </example>
    internal static string UnicodeNormalize(string input)
    {
        input = DiacriticsSorter.SortDiacritics(input);
        input = UnicodeSanitizer.SanitizeUnicode(input);

        return input;
    }
}