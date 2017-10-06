using Newtonsoft.Json;

namespace InstagramWrapper.DataModel
{
    [JsonObject("location")]
    public class Location
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("latitude")]
        public float Latitude { get; set; }
        [JsonProperty("longitude")]
        public float Longitude { get; set; }
    }
}
