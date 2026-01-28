using BlogCommunity.Api.Data.Entities;

namespace BlogCommunity.Api.Core.Interfaces
{
    public interface IPostService
    {

        Task<List<Post>> GetAllAsync();
        Task<Post?> GetByIdAsync(int id);

        Task<List<Post>> SearchByTitleAsync(string title);
        Task<List<Post>> SearchByCategoryAsync(int categoryId);

        Task<bool> CreateAsync(Post post, int userId);
        Task<bool> UpdateAsync(int postId, Post updatedPost, int userId);
        Task<bool> DeleteAsync(int postId, int userId);
    }
}
