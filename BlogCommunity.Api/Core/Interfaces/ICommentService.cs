using BlogCommunity.Api.Core.Enum;
using BlogCommunity.Api.Data.Entities;
using BlogCommunity.Api.Dtos.CommentDto;

namespace BlogCommunity.Api.Core.Interfaces
{
    public interface ICommentService
    {

        Task<CreateCommentResult> AddCommentAsync( int postId, CreateCommentDto dto,  int userId);


    }
}
