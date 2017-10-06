using InstagramWrapper.Api;
using InstagramWrapper.DataModel;
using System;

namespace InstagramWrapper.Endpoints
{
    public class TagService : EndpointServiceBase
    {
        private const string TagApi = "https://api.instagram.com/v1/tags/{0}?access_token={1}";
        private const string SearchTagApi = "https://api.instagram.com/v1/tags/search?q={0}&access_token={1}";

        public TagService(string accessToken)
        {
            AccessToken = accessToken;
        }

        public Uri TagApiUri(string tagName)
        {
            return new Uri(string.Format(TagApi, tagName, AccessToken));
        }
        public Uri SearchTagApiUri(string query)
        {
            return new Uri(string.Format(SearchTagApi, query, AccessToken));
        }

        /// <summary>
        /// Get information about a tag object.
        /// </summary>
        /// <param name="tagName">Location ID.</param>
        /// <returns>Information of a tag</returns>
        public Envelope<Tag> GetTagInfo(string tagName)
        {
            return new InstagramApiService<Tag>(this.TagApiUri(tagName)).Get();
        }
        /// <summary>
        /// Search for tags by name.
        /// </summary>
        /// <param name="query">A valid tag name without a leading #. (eg. snowy, nofilter)</param>
        /// <returns>List of matching tags</returns>
        public Envelope<Tag[]> SearchTags(string query)
        {
            return new InstagramApiService<Tag[]>(this.SearchTagApiUri(query)).Get();
        }
    }
}
