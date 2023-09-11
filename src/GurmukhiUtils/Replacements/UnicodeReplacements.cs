namespace GurmukhiUtils.Replacements;

internal class UnicodeReplacement
{
    internal static readonly Dictionary<string, string> AsciiToSlReplacements = new()
    {
        { "ˆØI", "ੀਁ" }, // Handle pre-bihari-bindi with unused adakbindi

        { "<>", "ੴ" }, // # AnmolLipi/GurbaniAkhar variant
        { "<", "ੴ" }, // GurbaniLipi variant
        { ">", "☬" }, // GurbaniLipi variant

        { "Åå", "ੴ" }, // AnmolLipi/GurbaniAkhar variant
        { "Å", "ੴ" }, // GurbaniLipi variant
        { "å", "ੴ" } // GurbaniLipi variant
    };

    internal static readonly Dictionary<string, string> UnicodeToSlReplacements = new()
    {
        {
            "੍ਯ", "꠳ਯ"
        } // replace unicode half-yayya with Sant Lipi ligature (north indic one-sixteenth fraction + yayya)
    };

    /*
     * Sant Lipi to Unicode Consortium
     * Avoiding a translation, in case these north indic fraction chars are used for what they're actually meant for
     */
    internal static readonly Dictionary<string, string> SlToUnicodeReplacements = new()
    {
        { "꠳ਯ", "੍ਯ" },
        { "꠴ਯ", "ਯ" },
        { "꠵ਯ", "੍ਯ" },
        { "ਁ", "ਂ" } // pre-bihari-bindi
    };
}