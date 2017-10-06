using InstagramWrapper.Api;
using InstagramWrapper.DataModel;
using System;

namespace InstagramWrapper.Endpoints
{
    public class UserMediaService : EndpointServiceBase
    {
        private const string UserRecentMediaApi = "https://api.instagram.com/v1/users/{0}/media/recent/?count={1}&access_token={2}";
        private const string SelfRecentLikedMediaApi = "https://api.instagram.com/v1/users/self/media/liked?count={0}&access_token={1}";

        public UserMediaService(string accessToken)
        {
            AccessToken = accessToken;
        }

        public Uri SelfRecentMediaApiUri(string count)
        {
            return new Uri(string.Format(UserRecentMediaApi, "self", count, AccessToken));
        }
        public Uri SelfRecentLikedMediaApiUri(string count)
        {
            return new Uri(string.Format(SelfRecentLikedMediaApi, count, AccessToken));
        }
        public Uri UserRecentMediaApiUri(string userId, string count)
        {
            return new Uri(string.Format(UserRecentMediaApi, userId, count, AccessToken));
        }

        /// <summary>
        /// Get the most recent media published by the owner of the access token.
        /// </summary>
        /// <param name="count">Count of media to return (Optional).</param>
        /// <returns>Recent Media published by the owner of the access token</returns>
        public Envelope<Media[]> GetSelfRecentMedia(int? count = null)
        {
            return new InstagramApiService<Media[]>(this.SelfRecentMediaApiUri(count == null ? string.Empty : count.ToString())).Get();
        }
        /// <summary>
        /// Get the list of recent media liked by the owner of the access token.
        /// </summary>
        /// <param name="count">Count of media to return (Optional).</param>
        /// <returns>Recent Media liked by the owner of the access token</returns>
        public Envelope<Media[]> GetSelfRecentLikedMedia(int? count = null)
        {
            return new InstagramApiService<Media[]>(this.SelfRecentLikedMediaApiUri(count == null ? string.Empty : count.ToString())).Get();
        }
        /// <summary>
        /// Get the most recent media published by a user.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="count">Count of media to return (Optional).</param>
        /// <returns>Recent Media published by a user</returns>
        public Envelope<Media[]> GetUserRecentMedia(string userId, int? count = null)
        {
            return new InstagramApiService<Media[]>(this.UserRecentMediaApiUri(userId, count == null ? string.Empty : count.ToString())).Get();
        }
    }
}
