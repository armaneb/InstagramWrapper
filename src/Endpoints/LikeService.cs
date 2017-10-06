using InstagramWrapper.Api;
using InstagramWrapper.DataModel;
using System;

namespace InstagramWrapper.Endpoints
{
    public class LikeService : EndpointServiceBase
    {
        private const string LikeApi = "https://api.instagram.com/v1/media/{0}/likes?access_token={1}";

        public LikeService(string accessToken)
        {
            AccessToken = accessToken;
        }

        public Uri LikeApiUri(string mediaId)
        {
            return new Uri(string.Format(LikeApi, mediaId, AccessToken));
        }

        /// <summary>
        /// Get a list of users who have liked this media.
        /// </summary>
        /// <param name="mediaId">Media ID.</param>
        /// <returns>List of users who have liked this media.</returns>
        public Envelope<User[]> GetLikers(string mediaId)
        {
            return new InstagramApiService<User[]>(this.LikeApiUri(mediaId)).Get();
        }
        /// <summary>
        /// Set a like on this media by the currently authenticated user.
        /// </summary>
        /// <param name="mediaId">Media ID.</param>
        /// <returns></returns>
        public Envelope<Object> Like(string mediaId)
        {
            return new InstagramApiService<Object>(this.LikeApiUri(mediaId)).Post();
        }
        /// <summary>
        /// Remove a like on this media by the currently authenticated user.
        /// </summary>
        /// <param name="mediaId">Media ID.</param>
        /// <returns></returns>
        public Envelope<Object> Unlike(string mediaId)
        {
            return new InstagramApiService<Object>(this.LikeApiUri(mediaId)).Delete();
        }
    }
}
