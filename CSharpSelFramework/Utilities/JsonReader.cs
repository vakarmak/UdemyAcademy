using Newtonsoft.Json.Linq;

namespace CSharpSelFramework.Utilities
{
    public class JsonReader
    {
        public string ExtractData(String tokenName)
        {
            var jsonString = File.ReadAllText("TestData/testData.json");
            var jsonObject = JToken.Parse(jsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }
    }
        
    
}