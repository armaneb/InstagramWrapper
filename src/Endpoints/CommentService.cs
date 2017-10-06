using InstagramWrapper.Api;
using InstagramWrapper.DataModel;
using System;
using System.Collections.Generic;

namespace InstagramWrapper.Endpoints
{
    public class CommentService : EndpointServiceBase
    {
        private const string CommentsApi = "https://api.instagram.com/v1/media/{0}/comments?access_token={1}";
        private const string CommentApi = "https://api.instagram.com/v1/media/{0}/comments/{1}?access_token={2}";

        public CommentService(string accessToken)
        {
            AccessToken = accessToken;
        }

        public Uri CommentsApiUri(string mediaId)
        {
            return new Uri(string.Format(CommentsApi, mediaId, AccessToken));
        }
        public Uri CommentApiUri(string mediaId, string commentId)
        {
            return new Uri(string.Format(CommentApi, mediaId, commentId, AccessToken));
        }

        /// <summary>
        /// Get a list of recent comments on a media object.
        /// </summary>
        /// <param name="mediaId">Media ID.</param>
        /// <returns>List of recent comments on a media object.</returns>
        public Envelope<Comment[]> GetComments(string mediaId)
        {
            return new InstagramApiService<Comment[]>(this.CommentsApiUri(mediaId)).Get();
        }
        /// <summary>
        /// Create a comment on a media object.
        /// </summary>
        /// <param name="mediaId">Media ID.</param>
        /// <param name="text">Comment text.
        /// <para />
        /// Note:
        ///     1- The total length of the comment cannot exceed 300 characters.
        ///     2- The comment cannot contain more than 4 hashtags.
        ///     3- The comment cannot contain more than 1 URL.
        ///     4- The comment cannot consist of all capital letters.</param>
        /// <returns>Created comment on media.</returns>
        public Envelope<Comment> WriteComment(string mediaId, string text)
        {
            return new InstagramApiService<Comment>(this.CommentsApiUri(mediaId))
                .Post(new KeyValuePair<string, string>("text", text));
        }
        /// <summary>
        /// Remove a comment either on the authenticated user's media object or authored by the authenticated user.
        /// </summary>
        /// <param name="mediaId">Media ID.</param>
        /// <param name="commentId">Comment ID.</param>
        /// <returns></returns>
        public Envelope<Object> RemoveComment(string mediaId, string commentId)
        {
            return new InstagramApiService<Object>(this.CommentApiUri(mediaId, commentId)).Delete();
        }
    }
}
