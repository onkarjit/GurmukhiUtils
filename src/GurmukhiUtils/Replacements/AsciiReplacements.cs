namespace GurmukhiUtils.Replacements;

internal class AsciiReplacement
{
    internal static readonly Dictionary<string, string> AsciiReplacements = new()
    {
        { "੍ਯ", "Î" }, // half-yayya
        { "꠳ਯ", "Î" }, // sant lipi variation
        { "꠴ਯ", "ï" }, // open-top yayya
        { "꠵ਯ", "î" }, // open-top half-yayya
        { "੍ਰ", "R" },
        { "੍ਵ", "Í" }, // capital i-acute letter
        { "੍ਹ", "H" },
        { "੍ਚ", "ç" }, // c-cedilla letter
        { "੍ਟ", "†" }, // dagger symbol
        { "੍ਤ", "œ" },
        { "੍ਨ", "˜" } // small tilde (˜)
    };
    
    // Make rendering changes for combos
    internal static readonly Dictionary<string, string> AsciiComboReplacements = new()
    {
        { "I\u0a01", "ˆØI" }, // bindi + bihari ligature
        { "IM", "µØI" }, // tippi + bihari ligature
        { "Iµ", "µØI" }, // tippi + bihari ligature
        { "kR", "k®" }, // kakka + pair-rara ligature
        { "H¨", "§" },
        { "wN", "W" }, // addhak positioning
        { "wˆ", "W" }, // addhak positioning
        { "nUµ", "ƒ" }
    };
}