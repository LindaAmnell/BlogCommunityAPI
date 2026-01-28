using BlogCommunity.Api.Data.Entities;

namespace BlogCommunity.Api.Data.Interfaces
{
    public interface ICommentRepo
    {
        Task AddAsync(Comment comment);
    }
}
