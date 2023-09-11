namespace GurmukhiUtils.Translations;

internal static class Translation
{
    /*
     * Font mapping
     * AnmolLipi/GurbaniAkhar & GurbaniLipi by Kulbir S. Thind, MD
     * OpenGurbaniAkhar by Sarabveer Singh (GurbaniNow)
     */
    internal static readonly Dictionary<string, string?> AsciiToSlTranslation = new()
    {
        { "a", "ੳ" },
        { "b", "ਬ" },
        { "c", "ਚ" },
        { "d", "ਦ" },
        { "e", "ੲ" },
        { "f", "ਡ" },
        { "g", "ਗ" },
        { "h", "ਹ" },
        { "i", "ਿ" },
        { "j", "ਜ" },
        { "k", "ਕ" },
        { "l", "ਲ" },
        { "m", "ਮ" },
        { "n", "ਨ" },
        { "o", "ੋ" },
        { "p", "ਪ" },
        { "q", "ਤ" },
        { "r", "ਰ" },
        { "s", "ਸ" },
        { "t", "ਟ" },
        { "u", "ੁ" },
        { "v", "ਵ" },
        { "w", "ਾ" },
        { "x", "ਣ" },
        { "y", "ੇ" },
        { "z", "ਜ਼" },
        { "A", "ਅ" },
        { "B", "ਭ" },
        { "C", "ਛ" },
        { "D", "ਧ" },
        { "E", "ਓ" },
        { "F", "ਢ" },
        { "G", "ਘ" },
        { "H", "੍ਹ" },
        { "I", "ੀ" },
        { "J", "ਝ" },
        { "K", "ਖ" },
        { "L", "ਲ਼" },
        { "M", "ੰ" },
        { "N", "ਂ" },
        { "O", "ੌ" },
        { "P", "ਫ" },
        { "Q", "ਥ" },
        { "R", "੍ਰ" },
        { "S", "ਸ਼" },
        { "T", "ਠ" },
        { "U", "ੂ" },
        { "V", "ੜ" },
        { "W", "ਾਂ" },
        { "X", "ਯ" },
        { "Y", "ੈ" },
        { "Z", "ਗ਼" },
        { "0", "੦" },
        { "1", "੧" },
        { "2", "੨" },
        { "3", "੩" },
        { "4", "੪" },
        { "5", "੫" },
        { "6", "੬" },
        { "7", "੭" },
        { "8", "੮" },
        { "9", "੯" },
        { "[", "।" },
        { "]", "॥" },
        { "\\", "ਞ" },
        { "|", "ਙ" },
        { "`", "ੱ" },
        { "~", "ੱ" },
        { "@", "ੑ" },
        { "^", "ਖ਼" },
        { "&", "ਫ਼" },
        { "†", "੍ਟ" }, // dagger symbol
        { "ü", "ੁ" }, // u-diaeresis letter
        { "®", "੍ਰ" }, // registered symbol
        { "\u00b4", "ੵ" }, // acute accent (´)
        { "\u00a8", "ੂ" }, // diaeresis accent (¨)
        { "µ", "ੰ" }, // mu letter
        { "æ", "਼" },
        { "\u00a1", "ੴ" }, // inverted exclamation (¡)
        { "ƒ", "ਨੂੰ" }, // florin symbol
        { "œ", "੍ਤ" },
        { "Í", "੍ਵ" }, // capital i-acute letter
        // { "Î", "੍ਯ" }, // capital i-circumflex letter
        { "Ï", "ੵ" }, // capital i-diaeresis letter
        { "Ò", "॥" }, // capital o-grave letter
        { "Ú", "ਃ" }, // capital u-acute letter
        { "\u02c6", "ਂ" }, // circumflex accent (ˆ)  
        { "\u02dc", "੍ਨ" }, // small tilde (˜)

        // AnmolLipi/GurbaniAkhar mappings:
        { "§", "੍ਹੂ" }, // section symbol
        { "¤", "ੱ" }, // currency symbol

        // GurbaniLipi mappings:
        { "ç", "੍ਚ" }, // c-cedilla letter

        // AnmolLipi/GurbaniAkhar overriding GurbaniLipi mapping:
        { "Ç", "☬" }, // khanda instead of california state symbol

        // Miscellaneous:
        { "\u201a", "❁" }, // single low-9 quotation (‚) mark

        /*
         * Nullify
         * Either the 2nd portion of ੴ or a symbol of USA:
         */
        { "Æ", null },
        { "Ø", null }, // This is a topline / shirorekha (शिरोरेखा) extender
        { "ÿ", null }, // This is the author Kulbir S Thind's stamp
        { "Œ", null }, // Box drawing left flower
        { "‰", null }, // Box drawing right flower
        { "Ó", null }, // Box drawing top flower
        { "Ô", null }, // Box drawing bottom flower

        /*
         * Open Gurbani Akhar
         * translate capital i-circumflex letter to indic one-sixteenth + yayya:
         */
        { "Î", "꠳ਯ" }, // half-yayya

        // translate i-diaeresis letter to indic one-eight + yayya:
        { "ï", "꠴ਯ" }, // open-top yayya

        // translate i-circumflex letter to indic three-sixtenths + yayya:
        { "î", "꠵ਯ" } // open-top half-yayya
    };

    internal static readonly Dictionary<string, string> AsciiTranslation = new()
    {
        ["ੳ"] = "a",
        ["ਅ"] = "A",
        ["ੲ"] = "e",
        ["ਸ"] = "s",
        ["ਹ"] = "h",
        ["ਕ"] = "k",
        ["ਖ"] = "K",
        ["ਗ"] = "g",
        ["ਘ"] = "G",
        ["ਙ"] = "|",
        ["ਚ"] = "c",
        ["ਛ"] = "C",
        ["ਜ"] = "j",
        ["ਝ"] = "J",
        ["ਞ"] = "\\",
        ["ਟ"] = "t",
        ["ਠ"] = "T",
        ["ਡ"] = "f",
        ["ਢ"] = "F",
        ["ਣ"] = "x",
        ["ਤ"] = "q",
        ["ਥ"] = "Q",
        ["ਦ"] = "d",
        ["ਧ"] = "D",
        ["ਨ"] = "n",
        ["ਪ"] = "p",
        ["ਫ"] = "P",
        ["ਬ"] = "b",
        ["ਭ"] = "B",
        ["ਮ"] = "m",
        ["ਯ"] = "X",
        ["ਰ"] = "r",
        ["ਲ"] = "l",
        ["ਵ"] = "v",
        ["ੜ"] = "V",
        ["ਸ਼"] = "S",
        ["ਜ਼"] = "z",
        ["ਖ਼"] = "^",
        ["ਫ਼"] = "&",
        ["ਗ਼"] = "Z",
        ["ਲ਼"] = "L",
        ["਼"] = "æ",
        ["ੑ"] = "@",
        ["ੵ"] = "\u00b4", // acute accent (´)
        ["ਃ"] = "Ú", // capital u-acute letter

        // Vowels and modifiers
        ["\u0a13"] = "E", // ਓ
        ["\u0a06"] = "Aw", // ਆ
        ["\u0a07"] = "ei", // ਇ
        ["\u0a08"] = "eI", // ਈ
        ["\u0a09"] = "au", // ਉ
        ["\u0a0a"] = "aU", // ਊ
        ["\u0a0f"] = "ey", // ਏ
        ["\u0a10"] = "AY", // ਐ
        ["\u0a14"] = "AO", // ਔ
        ["ਾ"] = "w",
        ["ਿ"] = "i",
        ["ੀ"] = "I",
        ["ੁ"] = "u",
        ["ੂ"] = "U",
        ["ੇ"] = "y",
        ["ੈ"] = "Y",
        ["ੋ"] = "o",
        ["ੌ"] = "O",
        ["ੰ"] = "M",
        ["ਂ"] = "N",
        ["ੱ"] = "~",

        // Punctuation and numbers
        ["।"] = "[",
        ["॥"] = "]",
        ["੦"] = "0",
        ["੧"] = "1",
        ["੨"] = "2",
        ["੩"] = "3",
        ["੪"] = "4",
        ["੫"] = "5",
        ["੬"] = "6",
        ["੭"] = "7",
        ["੮"] = "8",
        ["੯"] = "9",
        ["ੴ"] = "<>",
        ["☬"] = "Ç"
    };
}