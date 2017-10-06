namespace InstagramWrapper
{
    public enum LoginPermissionScope
    {
        /// <summary>
        /// to read a user’s profile info and media
        /// </summary>
        basic,
        /// <summary>
        /// to read any public profile info and media on a user’s behalf
        /// </summary>
        public_content,
        /// <summary>
        /// to read the list of followers and followed-by users
        /// </summary>
        follower_list,
        /// <summary>
        /// to post and delete comments on a user’s behalf
        /// </summary>
        comments,
        /// <summary>
        /// to follow and unfollow accounts on a user’s behalf
        /// </summary>
        relationships,
        /// <summary>
        /// to like and unlike media on a user’s behalf
        /// </summary>
        likes
    }

    public enum MediaType
    {
        image,
        video,
        carousel
    }

    public enum RelationshipOutgoingStatus
    {
        follows,
        requested,
        none
    }
    public enum RelationshipIncomingStatus
    {
        followed_by,
        requested_by,
        blocked_by_you,
        none
    }
    public enum RelationshipAction
    {
        follow,
        unfollow,
        approve,
        ignore
    }
}
