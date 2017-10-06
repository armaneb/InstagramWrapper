using Newtonsoft.Json;

namespace InstagramWrapper.DataModel
{
    public class Envelope<TType>
    {
        [JsonProperty("meta")]
        public Meta MetaData { get; set; }
        [JsonProperty("data")]
        public TType Data { get; set; }
        [JsonProperty("pagination")]
        public Pagination PaginationInfo { get; set; }

        [JsonObject("meta")]
        public class Meta
        {
            [JsonProperty("error_type")]
            public string ErrorType { get; set; }
            [JsonProperty("code")]
            public int Code { get; set; }
            [JsonProperty("error_message")]
            public string ErrorMessage { get; set; }
        }

        [JsonObject("pagination")]
        public class Pagination
        {
            [JsonProperty("next_url")]
            public string NextUrl { get; set; }
            [JsonProperty("next_max_id")]
            public string NextMaxId { get; set; }
        }
    }
}
