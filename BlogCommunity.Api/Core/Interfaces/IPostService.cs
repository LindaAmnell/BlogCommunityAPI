using BlogCommunity.Api.Core.Enum;
using BlogCommunity.Api.Data.Entities;
using BlogCommunity.Api.Dtos.postDto;

namespace BlogCommunity.Api.Core.Interfaces
{
    public interface IPostService
    {

        Task<List<Post>> GetAllAsync();
        Task<Post?> GetByIdAsync(int id);

        Task<List<Post>> SearchByTitleAsync(string title);
        Task<List<Post>> SearchByCategoryAsync(int categoryId);

        Task<CreatePostResult> CreateAsync(Post post, int userId);

        Task<bool> UpdateAsync(int postId, UpdatePostDto updatedPost, int userId);
        Task<bool> DeleteAsync(int postId, int userId);
    }
}
