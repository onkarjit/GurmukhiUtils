using System.Reflection;
using GurmukhiUtils.Tests.Models;
using Newtonsoft.Json;

namespace GurmukhiUtils.Tests;

internal static class TestLoader
{
    internal static async Task<TestData?> LoadTestDataAsync(string fileName)
    {
        string fullPath;

        if (Environment.GetEnvironmentVariable("CI") == "true")
        {
            // CI environment
            fullPath = Path.Combine(Directory.GetCurrentDirectory(), "test", fileName);
        }
        else
        {
            // Local development environment
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        
            if (path == null) return null;

            fullPath = Path.Combine(path, "tests", fileName);
        }

        if (!File.Exists(fullPath)) return null;

        var jsonString = await File.ReadAllTextAsync(fullPath);
        return JsonConvert.DeserializeObject<TestData>(jsonString);
    }
}

    