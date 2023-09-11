using GurmukhiUtils.Converters;
using GurmukhiUtils.Enums;

namespace GurmukhiUtils;

public class GurmukhiUtils
{
    /// <summary>
    /// Converts any ASCII Gurmukhi characters and sanitizes to Unicode Gurmukhi.
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
    /// The mapping system to use. The default is Unicode compliant and can render 99% of the Shabad OS Database. 
    /// The other option "Sant Lipi" is intended for a custom Unicode font bearing the same name 
    /// (see: <see href="https://github.com/shabados/SantLipi"/>). Defaults to "Unicode Consortium".
    /// </para>
    /// </remarks>
    /// <param name="input">The string to affect.</param>
    /// <param name="unicodeStandard">The Unicode standard to use for conversion.</param>
    /// <returns>A string whose Gurmukhi is normalized to a Unicode standard.</returns>
    /// <example>
    /// <code>
    /// var result1 = ConvertToUnicode("123");
    /// Console.WriteLine(result1);  // Outputs: '੧੨੩'
    ///
    /// var result2 = ConvertToUnicode("&lt;&gt; &gt; &lt;");
    /// Console.WriteLine(result2);  // Outputs: 'ੴ ☬ ੴ'
    ///
    /// var result3 = ConvertToUnicode("gurU");
    /// Console.WriteLine(result3);  // Outputs: 'ਗੁਰੂ'
    /// </code>
    /// </example>
    public static string ToUnicode(string input,
        UnicodeStandards unicodeStandard = UnicodeStandards.UnicodeConsortium)
    {
        return Unicode.Convert(input, unicodeStandard);
    }
    
    /// <summary>
    /// Converts Gurmukhi to ASCII for Open Gurbani Akhar font.
    /// Open Gurbani Akhar is the only font that can fully render the Shabad OS Database. Historically, every other ASCII font has been insufficiently capable.
    /// </summary>
    /// <param name="input">The string to affect.</param>
    /// <returns>A string whose Gurmukhi is converted to an ascii font format.</returns>
    public static string ToAscii(string input)
    {
        return Ascii.Convert(input);
    }
}