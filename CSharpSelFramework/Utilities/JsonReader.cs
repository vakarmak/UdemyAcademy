using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CSharpSelFramework.Utilities
{
    internal class JsonReader
    {
        public void ExtractData()
        {
            var jsonString = File.ReadAllText("testData.json");
            var jsonObject = JToken.Parse(jsonString);
            Console.WriteLine(jsonObject.SelectToken("username").Value<string>());
        }
    }
        
    
}