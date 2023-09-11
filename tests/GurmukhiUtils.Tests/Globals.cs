namespace GurmukhiUtils.Tests;

using System;
using Xunit;

internal static class Globals
{
    internal static void GuutIs(Func<string, string> func, string input, string expected)
    {
        Assert.Equal(expected, func(input));
    }

    internal static void GuutIsNot(Func<string, string> func, string input, string unexpected)
    {
        Assert.NotEqual(unexpected, func(input));
    }

    internal static void GuutThrows(Func<string, string> func, string input)
    {
        Assert.Throws<Exception>(() => func(input));
    }

    internal static void GuutMatch(string type, Func<string, string> func, string input, string expected = "")
    {
        switch (type)
        {
            case "is":
                GuutIs(func, input, expected);
                break;
            case "is not":
                GuutIsNot(func, input, expected);
                break;
            case "throws":
                GuutThrows(func, input);
                break;
        }
    }
}