namespace GurmukhiUtils.Helpers;

/// <summary>
/// Sanitizes a Gurmukhi string according to Unicode Standards.
/// </summary>
internal static class UnicodeSanitizer
{
    // Use single char representations of constructed characters.
    private static readonly Dictionary<string, string> UnicodeSanitizationMap = new()
    {
        { "\u0a73\u0a4b", "\u0a13" }, // ਓ
        { "\u0a05\u0a3e", "\u0a06" }, // ਅ + ਾ = ਆ
        { "\u0a72\u0a3f", "\u0a07" }, // ਇ
        { "\u0a72\u0a40", "\u0a08" }, // ਈ
        { "\u0a73\u0a41", "\u0a09" }, // ਉ
        { "\u0a73\u0a42", "\u0a0a" }, // ਊ
        { "\u0a72\u0a47", "\u0a0f" }, // ਏ
        { "\u0a05\u0a48", "\u0a10" }, // ਐ
        { "\u0a05\u0a4c", "\u0a14" }, // ਔ
        { "\u0a32\u0a3c", "\u0a33" }, // ਲ਼
        { "\u0a38\u0a3c", "\u0a36" }, // ਸ਼
        { "\u0a16\u0a3c", "\u0a59" }, // ਖ਼
        { "\u0a17\u0a3c", "\u0a5a" }, // ਗ਼
        { "\u0a1c\u0a3c", "\u0a5b" }, // ਜ਼
        { "\u0a2b\u0a3c", "\u0a5e" }, // ਫ਼
        { "\u0a71\u0a02", "\u0a01" }  // ਁ
    };

    /// <summary>
    /// Sanitizes the Gurmukhi characters in the input string.
    /// </summary>
    /// <param name="input">The string to sanitize.</param>
    /// <returns>The sanitized string.</returns>
    public static string SanitizeUnicode(string input)
    {
        foreach (var pair in UnicodeSanitizationMap)
        {
            input = input.Replace(pair.Key, pair.Value);
        }
        return input;
    }
}