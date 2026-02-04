namespace BlogCommunity.Api.Core.Enum
{
    public enum CreateCommentResult
    {
        Success,
        UserNotFound,
        PostNotFound,
        CannotCommentOwnPost
    }

}
