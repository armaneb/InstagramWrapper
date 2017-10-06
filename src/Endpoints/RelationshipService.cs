using InstagramWrapper.Api;
using InstagramWrapper.DataModel;
using System;
using System.Collections.Generic;

namespace InstagramWrapper.Endpoints
{
    public class RelationshipService : EndpointServiceBase
    {
        private const string FollowingListApi = "https://api.instagram.com/v1/users/self/follows?access_token={0}";
        private const string FollowerListApi = "https://api.instagram.com/v1/users/self/followed-by?access_token={0}";
        private const string RequesterListApi = "https://api.instagram.com/v1/users/self/requested-by?access_token={0}";
        private const string RelationshipApi = "https://api.instagram.com/v1/users/{0}/relationship?access_token={1}";

        public RelationshipService(string accessToken)
        {
            AccessToken = accessToken;
        }

        public Uri FollowingListApiUri()
        {
            return new Uri(string.Format(FollowingListApi, AccessToken));
        }
        public Uri FollowerListApiUri()
        {
            return new Uri(string.Format(FollowerListApi, AccessToken));
        }
        public Uri RequesterListApiUri()
        {
            return new Uri(string.Format(RequesterListApi, AccessToken));
        }
        public Uri RelationshipApiUri(string userId)
        {
            return new Uri(string.Format(RelationshipApi, userId, AccessToken));
        }

        /// <summary>
        /// Get the list of users this user follows.
        /// </summary>
        /// <returns>Following users.</returns>
        public Envelope<User[]> GetFollowingUsers()
        {
            return new InstagramApiService<User[]>(this.FollowingListApiUri()).Get();
        }
        /// <summary>
        /// Get the list of users this user is followed by.
        /// </summary>
        /// <returns>Follower users.</returns>
        public Envelope<User[]> GetFollowerUsers()
        {
            return new InstagramApiService<User[]>(this.FollowerListApiUri()).Get();
        }
        /// <summary>
        /// List the users who have requested this user's permission to follow.
        /// </summary>
        /// <returns>Requester users to follow.</returns>
        public Envelope<User[]> GetRequesterUsers()
        {
            return new InstagramApiService<User[]>(this.RequesterListApiUri()).Get();
        }
        /// <summary>
        /// Get information about a relationship to another user.
        /// </summary>
        /// <param name="targetUserId">Target user ID.</param>
        /// <returns>Information about a relationship to another user.</returns>
        public Envelope<Relationship> GetRelationshipInfo(string targetUserId)
        {
            return new InstagramApiService<Relationship>(this.RelationshipApiUri(targetUserId)).Get();
        }
        /// <summary>
        /// Modify the relationship between the current user and the target user.
        /// </summary>
        /// <param name="targetUserId">Target user ID.</param>
        /// <param name="relationshipAction">Modify action: follow | unfollow | approve | ignore</param>
        /// <returns>Last state of relationship between current and target user.</returns>
        public Envelope<Relationship> ModifyRelationship(string targetUserId, RelationshipAction relationshipAction)
        {
            return new InstagramApiService<Relationship>(RelationshipApiUri(targetUserId))
                .Post(new KeyValuePair<string, string>("action", relationshipAction.ToString()));
        }
    }
}
