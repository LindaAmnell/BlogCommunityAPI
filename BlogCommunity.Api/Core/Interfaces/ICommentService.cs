using BlogCommunity.Api.Data.Entities;

namespace BlogCommunity.Api.Core.Interfaces
{
    public interface ICommentService
    {

        Task<bool> AddCommentAsync(Comment comment, int UserId);

    }
}
