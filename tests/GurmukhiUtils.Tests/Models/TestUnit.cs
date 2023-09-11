using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GurmukhiUtils.Tests.Models;

internal class TestUnit
{
    public string Name { get; set; }
    public List<string> Functions { get; set; }
    public string Type { get; set; }
    
    public List<string> AssertionsList { get; private set; }
    public Dictionary<string, string> AssertionsDict { get; private set; }

    [JsonProperty("Assertions")]
    private JToken AssertionsJson
    {
        set
        {
            switch (value.Type)
            {
                case JTokenType.Array:
                    AssertionsList = value.ToObject<List<string>>();
                    break;
                case JTokenType.Object:
                    AssertionsDict = value.ToObject<Dictionary<string, string>>();
                    break;
            }
        }
    }

    public bool AssertionsIsArray => AssertionsList != null;
}