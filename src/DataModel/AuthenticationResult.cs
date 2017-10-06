using Newtonsoft.Json;

namespace InstagramWrapper.DataModel
{
    public class AuthenticationResult
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("user")]
        public User User { get; set; }
    }
}
