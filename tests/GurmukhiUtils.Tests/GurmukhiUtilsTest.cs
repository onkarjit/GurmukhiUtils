using GurmukhiUtils.Enums;
using GurmukhiUtils.Tests.Models;

namespace GurmukhiUtils.Tests;

public class GurmukhiUtilsTest
{
    private static readonly Func<string, string> Unicode = str => GurmukhiUtils.ToUnicode(str);
    private static readonly Func<string, string> Unicode3 = str => Unicode(Unicode(Unicode(str)));
    private static readonly Func<string, string> Santlipi = str => GurmukhiUtils.ToUnicode(str, UnicodeStandards.SantLipi);
    private static readonly Func<string, string> Santlipi3 = str => Santlipi(Santlipi(Santlipi(str)));
    private static readonly Func<string, string> Unisant = str => Unicode(Santlipi(str));
    private static readonly Func<string, string> Unisant2 = str => Unisant(Unisant(str));
    private static readonly Func<string, string> Ascii = GurmukhiUtils.ToAscii;
    
    private static readonly Dictionary<string, Func<string, string>> Funcs = new()
    {
        { "unicode", Unicode },
        { "unicode3", Unicode3 },
        { "santlipi", Santlipi },
        { "santlipi3", Santlipi3 },
        { "unisant", Unisant },
        { "unisant2", Unisant2 },
        { "ascii", Ascii }
    };

    [Fact]
    public async void ToUnicodeTestAsync()
    {
        var fileName = Environment.GetEnvironmentVariable("UNICODE_TEST_FILE") ?? "toUnicode.json";
        var testData = await TestLoader.LoadTestDataAsync(fileName);
        Assert.NotNull(testData);
        ExecuteTest(testData);
    }
    
    [Fact]
    public async void ToAsciiTestAsync()
    {
        var fileName = Environment.GetEnvironmentVariable("ASCII_TEST_FILE") ?? "toAscii.json";
        var testData = await TestLoader.LoadTestDataAsync(fileName);
        Assert.NotNull(testData);
        ExecuteTest(testData);
    }
    
    private void ExecuteTest(TestData testData)
    {
        foreach (var unit in testData.Tests)
        {
            foreach (var funcName in unit.Functions)
            {
                var func = Funcs[funcName];
                if (unit.AssertionsIsArray)
                {
                    foreach (var ele in unit.AssertionsList)
                    {
                        Globals.GuutMatch(unit.Type, input => func(input), ele);
                    }
                }
                else
                {
                    foreach (var kvp in unit.AssertionsDict)
                    {
                        Globals.GuutMatch(unit.Type, input => func(input), kvp.Key, kvp.Value);
                    }
                }
            }
        }
    }
}