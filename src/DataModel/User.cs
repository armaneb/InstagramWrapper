using Newtonsoft.Json;

namespace InstagramWrapper.DataModel
{
    [JsonObject("user")]
    public class User
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("profile_picture")]
        public string ProfilePictureUrl { get; set; }
        [JsonProperty("bio")]
        public string Bio { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }
        [JsonProperty("counts")]
        public Counts CountsInfo { get; set; }

        [JsonObject("counts")]
        public class Counts
        {
            [JsonProperty("media")]
            public int Media { get; set; }
            [JsonProperty("follows")]
            public int Follows { get; set; }
            [JsonProperty("followed_by")]
            public int FollowedBy { get; set; }
        }
    }
}
