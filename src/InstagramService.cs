using InstagramWrapper.DataModel;
using InstagramWrapper.Endpoints;
using System;
using System.Windows;

namespace InstagramWrapper
{
    public class InstagramService
    {
        #region Properties

        public string AccessToken { get; set; }

        #endregion

        #region Constructors

        public InstagramService() { }
        public InstagramService(string accessToken)
        {
            AccessToken = accessToken;
        }

        #endregion

        #region Authentication Methods

        /// <summary>
        /// (For WPF platform)
        /// Authenticate user and return her access token.
        /// throw an exception with proper message, if can't grab user access token.
        /// </summary>
        /// <param name="ownerWindow">Owner window that called authenticator window.</param>
        /// <param name="clientId">Client ID of your registered application.</param>
        /// <param name="redirectUri">Redirect URI of your registered application.</param>
        /// <param name="loginPermissionScopes">Permission scopes that need to be granted.</param>
        public string Authenticate(Window ownerWindow, string clientId, string redirectUri, params LoginPermissionScope[] loginPermissionScopes)
        {
            var authentication = new Authentication.AuthenticationService(clientId, redirectUri, loginPermissionScopes);
            var authenticationWin = new Authentication.AuthenticationWindow(authentication) { Owner = ownerWindow };

            authenticationWin.ShowDialogWithEffect();

            return AccessToken = authenticationWin.AccessToken;
        }

        #endregion

        #region Endpoint Methods

        #region User Methods

        /// <summary>
        /// Get information about the owner of the access token.
        /// </summary>
        public Envelope<User> GetSelfInfo()
        {
            return new UserService(AccessToken).GetSelfInfo();
        }
        /// <summary>
        /// Get a list of users matching the query.
        /// </summary>
        /// <param name="query">A query string.</param>
        /// <param name="count">Number of users to return (Optional).</param>
        /// <returns>List of matching users</returns>
        public Envelope<User[]> SearchUsers(string query, int? count = null)
        {
            return new UserService(AccessToken).SearchUsers(query, count);
        }
        /// <summary>
        /// Get information about a user.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <returns>Information of user</returns>
        public Envelope<User> GetUserInfo(string userId)
        {
            return new UserService(AccessToken).GetUserInfo(userId);
        }

        #endregion

        #region Media Methods

        /// <summary>
        /// Get information about a media object.
        /// </summary>
        /// <param name="mediaId">Media ID.</param>
        /// <returns>Information of media object</returns>
        public Envelope<Media> GetMediaById(string mediaId)
        {
            return new MediaService(AccessToken).GetMediaById(mediaId);
        }
        /// <summary>
        /// Get information about a media object.
        /// </summary>
        /// <param name="mediaShortcode">Media Shortcode.</param>
        /// <returns>Information of media object</returns>
        public Envelope<Media> GetMediaByShortcode(string mediaShortcode)
        {
            return new MediaService(AccessToken).GetMediaByShortcode(mediaShortcode);
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
            return new MediaService(AccessToken).SearchMediaByLocation(latitude, longitude, distance);
        }
        /// <summary>
        /// Get a list of recently tagged media.
        /// </summary>
        /// <param name="tagName">Tag Name.</param>
        /// <param name="count">Count of tagged media to return. (Optional)</param>
        /// <returns>List of recently tagged media.</returns>
        public Envelope<Media[]> SearchRecentlyTaggedMedia(string tagName, int? count = null)
        {
            return new MediaService(AccessToken).SearchRecentlyTaggedMedia(tagName, count);
        }

        #endregion

        #region Location Methods

        /// <summary>
        /// Get information about a location.
        /// </summary>
        /// <param name="locationId">Location ID.</param>
        /// <returns>Information of a location</returns>
        public Envelope<Location> GetLocationById(string locationId)
        {
            return new LocationService(AccessToken).GetLocationById(locationId);
        }
        /// <summary>
        /// Search for a location by geographic coordinate.
        /// </summary>
        /// <param name="latitude">Latitude of the center search coordinate. If used, longitude is required.</param>
        /// <param name="longitude">Longitude of the center search coordinate. If used, latitude is required.</param>
        /// <param name="distance">Default is 500m (distance=500), max distance is 750m.</param>
        /// <returns>List of locations</returns>
        public Envelope<Location[]> SearchLocations(float latitude, float longitude, int distance = 500)
        {
            return new LocationService(AccessToken).SearchLocations(latitude, longitude, distance);
        }

        #endregion

        #region Tag Methods

        /// <summary>
        /// Get information about a tag object.
        /// </summary>
        /// <param name="tagName">Location ID.</param>
        /// <returns>Information of a tag</returns>
        public Envelope<Tag> GetTagInfo(string tagName)
        {
            return new TagService(AccessToken).GetTagInfo(tagName);
        }
        /// <summary>
        /// Search for tags by name.
        /// </summary>
        /// <param name="query">A valid tag name without a leading #. (eg. snowy, nofilter)</param>
        /// <returns>List of matching tags</returns>
        public Envelope<Tag[]> SearchTags(string query)
        {
            return new TagService(AccessToken).SearchTags(query);
        }

        #endregion

        #region UserMedia Methods

        /// <summary>
        /// Get the most recent media published by the owner of the access token.
        /// </summary>
        /// <param name="count">Count of media to return (Optional).</param>
        /// <returns>Recent Media published by the owner of the access token</returns>
        public Envelope<Media[]> GetSelfRecentMedia(int? count = null)
        {
            return new UserMediaService(AccessToken).GetSelfRecentMedia(count);
        }
        /// <summary>
        /// Get the list of recent media liked by the owner of the access token.
        /// </summary>
        /// <param name="count">Count of media to return (Optional).</param>
        /// <returns>Recent Media liked by the owner of the access token</returns>
        public Envelope<Media[]> GetSelfRecentLikedMedia(int? count = null)
        {
            return new UserMediaService(AccessToken).GetSelfRecentLikedMedia(count);
        }
        /// <summary>
        /// Get the most recent media published by a user.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="count">Count of media to return (Optional).</param>
        /// <returns>Recent Media published by a user</returns>
        public Envelope<Media[]> GetUserRecentMedia(string userId, int? count = null)
        {
            return new UserMediaService(AccessToken).GetUserRecentMedia(userId, count);
        }

        #endregion

        #region Relationship Methods

        /// <summary>
        /// Get the list of users this user follows.
        /// </summary>
        /// <returns>Following users.</returns>
        public Envelope<User[]> GetFollowingUsers()
        {
            return new RelationshipService(AccessToken).GetFollowingUsers();
        }
        /// <summary>
        /// Get the list of users this user is followed by.
        /// </summary>
        /// <returns>Follower users.</returns>
        public Envelope<User[]> GetFollowerUsers()
        {
            return new RelationshipService(AccessToken).GetFollowerUsers();
        }
        /// <summary>
        /// List the users who have requested this user's permission to follow.
        /// </summary>
        /// <returns>Requester users to follow.</returns>
        public Envelope<User[]> GetRequesterUsers()
        {
            return new RelationshipService(AccessToken).GetRequesterUsers();
        }
        /// <summary>
        /// Get information about a relationship to another user.
        /// </summary>
        /// <param name="targetUserId">Target user ID.</param>
        /// <returns>Information about a relationship to another user.</returns>
        public Envelope<Relationship> GetRelationshipInfo(string targetUserId)
        {
            return new RelationshipService(AccessToken).GetRelationshipInfo(targetUserId);
        }
        /// <summary>
        /// Modify the relationship between the current user and the target user.
        /// </summary>
        /// <param name="targetUserId">Target user ID.</param>
        /// <param name="relationshipAction">Modify action: follow | unfollow | approve | ignore</param>
        /// <returns>Last state of relationship between current and target user.</returns>
        public Envelope<Relationship> ModifyRelationship(string targetUserId, RelationshipAction relationshipAction)
        {
            return new RelationshipService(AccessToken).ModifyRelationship(targetUserId, relationshipAction);
        }

        #endregion

        #region Like Methods

        /// <summary>
        /// Get a list of users who have liked this media.
        /// </summary>
        /// <param name="mediaId">Media ID.</param>
        /// <returns>List of users who have liked this media.</returns>
        public Envelope<User[]> GetLikers(string mediaId)
        {
            return new LikeService(AccessToken).GetLikers(mediaId);
        }
        /// <summary>
        /// Set a like on this media by the currently authenticated user.
        /// </summary>
        /// <param name="mediaId">Media ID.</param>
        /// <returns></returns>
        public Envelope<Object> Like(string mediaId)
        {
            return new LikeService(AccessToken).Like(mediaId);
        }
        /// <summary>
        /// Remove a like on this media by the currently authenticated user.
        /// </summary>
        /// <param name="mediaId">Media ID.</param>
        /// <returns></returns>
        public Envelope<Object> Unlike(string mediaId)
        {
            return new LikeService(AccessToken).Unlike(mediaId);
        }

        #endregion

        #region Comment Methods

        /// <summary>
        /// Get a list of recent comments on a media object.
        /// </summary>
        /// <param name="mediaId">Media ID.</param>
        /// <returns>List of recent comments on a media object.</returns>
        public Envelope<Comment[]> GetComments(string mediaId)
        {
            return new CommentService(AccessToken).GetComments(mediaId);
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
            return new CommentService(AccessToken).WriteComment(mediaId, text);
        }
        /// <summary>
        /// Remove a comment either on the authenticated user's media object or authored by the authenticated user.
        /// </summary>
        /// <param name="mediaId">Media ID.</param>
        /// <param name="commentId">Comment ID.</param>
        /// <returns></returns>
        public Envelope<Object> RemoveComment(string mediaId, string commentId)
        {
            return new CommentService(AccessToken).RemoveComment(mediaId, commentId);
        }

        #endregion

        #endregion
    }
}
