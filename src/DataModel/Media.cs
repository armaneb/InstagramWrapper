using Newtonsoft.Json;
using System;

namespace InstagramWrapper.DataModel
{
    [JsonObject("media")]
    public class Media
    {
        [JsonProperty("distance")]
        public double Distance { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("users_in_photo")]
        public UserInPhoto[] UsersInPhoto { get; set; }
        [JsonProperty("filter")]
        public string Filter { get; set; }
        [JsonProperty("tags")]
        public string[] Tags { get; set; }
        [JsonProperty("comments")]
        public Counts Comments { get; set; }
        [JsonProperty("caption")]
        public Caption CaptionInfo { get; set; }
        [JsonProperty("likes")]
        public Counts Likes { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("user")]
        public User User { get; set; }
        [JsonProperty("created_time")]
        public string CreatedTime { get; set; }
        [JsonProperty("images")]
        public MediaDetails ImagesInfo { get; set; }
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("location")]
        public Location Location { get; set; }
        [JsonProperty("carousel_media")]
        public Media[] CarouselMedia { get; set; }

        public MediaType MediaType
        {
            get
            {
                return (MediaType)Enum.Parse(typeof(MediaType), this.Type, true);
            }
        }
        public DateTime? CreatedDateTime
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(CreatedTime))
                    return new DateTime(Convert.ToInt64(CreatedTime));
                else
                    return null;
            }
        }

        [JsonObject("user_in_photo")]
        public class UserInPhoto
        {
            [JsonProperty("user")]
            public User User { get; set; }
            [JsonProperty("position")]
            public Point Position { get; set; }

            [JsonObject("position")]
            public class Point
            {
                [JsonProperty("x")]
                public float X { get; set; }
                [JsonProperty("y")]
                public float Y { get; set; }
            }
        }

        [JsonObject("caption")]
        public class Caption
        {
            [JsonProperty("id")]
            public string ID { get; set; }
            [JsonProperty("from")]
            public User From { get; set; }
            [JsonProperty("created_time")]
            public string CreatedTime { get; set; }
            [JsonProperty("text")]
            public string Text { get; set; }
        }

        [JsonObject("counts")]
        public class Counts
        {
            [JsonProperty("count")]
            public int Count { get; set; }
        }

        [JsonObject("media_details")]
        public class MediaDetails
        {
            [JsonProperty("low_resolution")]
            public MediaDetail LowResolution { get; set; }
            [JsonProperty("low_bandwidth")]
            public MediaDetail LowBandwidth { get; set; }
            [JsonProperty("thumbnail")]
            public MediaDetail Thumbnail { get; set; }
            [JsonProperty("standard_resolution")]
            public MediaDetail StandardResolution { get; set; }

            [JsonObject("media_detail")]
            public class MediaDetail
            {
                [JsonProperty("url")]
                public string Url { get; set; }
                [JsonProperty("width")]
                public int Width { get; set; }
                [JsonProperty("height")]
                public int Height { get; set; }
            }
        }
    }
}
