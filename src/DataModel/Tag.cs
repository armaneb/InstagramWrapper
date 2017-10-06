using Newtonsoft.Json;

namespace InstagramWrapper.DataModel
{
    [JsonObject("tag")]
    public class Tag
    {
        [JsonProperty("media_count")]
        public int MediaCount { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
