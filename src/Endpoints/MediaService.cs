using InstagramWrapper.Api;
using InstagramWrapper.DataModel;
using System;

namespace InstagramWrapper.Endpoints
{
    public class MediaService : EndpointServiceBase
    {
        private const string MediaByShortcodeApi = "https://api.instagram.com/v1/media/{0}/D?access_token={1}";
        private const string MediaByIdApi = "https://api.instagram.com/v1/media/{0}?access_token={1}";
        private const string SearchMediaByLocationApi = "https://api.instagram.com/v1/media/search?lat={0}&lng={1}&distance={2}&access_token={3}";
        private const string SearchRecentlyTaggedMediaApi = "https://api.instagram.com/v1/tags/{0}/media/recent?count={1}&access_token={2}";

        public MediaService(string accessToken)
        {
            AccessToken = accessToken;
        }

        public Uri MediaByShortcodeApiUri(string mediaShortcode)
        {
            return new Uri(string.Format(MediaByShortcodeApi, mediaShortcode, AccessToken));
        }
        public Uri MediaByIdApiUri(string mediaId)
        {
            return new Uri(string.Format(MediaByIdApi, mediaId, AccessToken));
        }
        public Uri SearchMediaByLocationApiUri(string latitude, string longitude, string distance)
        {
            return new Uri(string.Format(SearchMediaByLocationApi, latitude, longitude, distance, AccessToken));
        }
        public Uri SearchRecentlyTaggedMediaApiUri(string tagName, string count)
        {
            return new Uri(string.Format(SearchRecentlyTaggedMediaApi, tagName, count, AccessToken));
        }

        /// <summary>
        /// Get information about a media object.
        /// </summary>
        /// <param name="mediaShortcode">Media Shortcode.</param>
        /// <returns>Information of media object</returns>
        public Envelope<Media> GetMediaByShortcode(string mediaShortcode)
        {
            return new InstagramApiService<Media>(this.MediaByShortcodeApiUri(mediaShortcode)).Get();
        }
        /// <summary>
        /// Get information about a media object.
        /// </summary>
        /// <param name="mediaId">Media ID.</param>
        /// <returns>Information of media object</returns>
        public Envelope<Media> GetMediaById(string mediaId)
        {
            return new InstagramApiService<Media>(this.MediaByIdApiUri(mediaId)).Get();
        }
        /// <summary>
        /// Search for recent media in a given area.
        /// </summary>
        /// <param name="latitude">Latitude of the center search coordinate. If used, longitude is required.</param>
        /// <param name="longitude">Longitude of the center search coordinate. If used, latitude is required.</param>
        /// <param name="distance">Default is 1km (distance=1000), max distance is 5km.</param>
        /// <returns>List of recent media</returns>
        public Envelope<Media[]> SearchMediaByLocation(float latitude, float longitude, int distance = 1000)
        {
            return new InstagramApiService<Media[]>(this.SearchMediaByLocationApiUri(latitude.ToString(), longitude.ToString(), distance.ToString())).Get();
        }
        /// <summary>
        /// Get a list of recently tagged media.
        /// </summary>
        /// <param name="tagName">Tag Name.</param>
        /// <param name="count">Count of tagged media to return. (Optional)</param>
        /// <returns>List of recently tagged media.</returns>
        public Envelope<Media[]> SearchRecentlyTaggedMedia(string tagName, int? count = null)
        {
            return new InstagramApiService<Media[]>(this.SearchRecentlyTaggedMediaApiUri(tagName, count == null ? string.Empty : count.ToString())).Get();
        }
    }
}
