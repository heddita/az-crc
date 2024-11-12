using Newtonsoft.Json;

namespace Company.Function
{
    public class Counter
    {
        [JsonProperty(PropertyName = "id")]
        public string Id {get;set;}
        [JSonProperty(PropertyName = "count")]
        public int Count {get;set;}
    }
}