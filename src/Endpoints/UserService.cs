using InstagramWrapper.Api;
using InstagramWrapper.DataModel;
using System;

namespace InstagramWrapper.Endpoints
{
    public class UserService : EndpointServiceBase
    {
        private const string UserApi = "https://api.instagram.com/v1/users/{0}/?access_token={1}";
        private const string SearchUserApi = "https://api.instagram.com/v1/users/search?q={0}&count={1}&access_token={2}";

        public UserService(string accessToken)
        {
            AccessToken = accessToken;
        }

        public Uri SelfApiUri()
        {
            return new Uri(string.Format(UserApi, "self", AccessToken));
        }
        public Uri SearchUserApiUri(string query, string count)
        {
            return new Uri(string.Format(SearchUserApi, query, count, AccessToken));
        }
        public Uri UserApiUri(string userId)
        {
            return new Uri(string.Format(UserApi, userId, AccessToken));
        }

        /// <summary>
        /// Get information about the owner of the access token.
        /// </summary>
        /// <returns>Owner of access token user</returns>
        public Envelope<User> GetSelfInfo()
        {
            return new InstagramApiService<User>(this.SelfApiUri()).Get();
        }
        /// <summary>
        /// Get a list of users matching the query.
        /// </summary>
        /// <param name="query">A query string.</param>
        /// <param name="count">Number of users to return (Optional).</param>
        /// <returns>List of matching users</returns>
        public Envelope<User[]> SearchUsers(string query, int? count = null)
        {
            return new InstagramApiService<User[]>(this.SearchUserApiUri(query, count == null ? string.Empty : count.ToString())).Get();
        }
        /// <summary>
        /// Get information about a user.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <returns>Information of user</returns>
        public Envelope<User> GetUserInfo(string userId)
        {
            return new InstagramApiService<User>(this.UserApiUri(userId)).Get();
        }
    }
}
