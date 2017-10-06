using Newtonsoft.Json;

namespace InstagramWrapper.DataModel
{
    [JsonObject("comment")]
    public class Comment
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("created_time")]
        public string CreatedTime { get; set; }
        [JsonProperty("from")]
        public User From { get; set; }
    }
}
