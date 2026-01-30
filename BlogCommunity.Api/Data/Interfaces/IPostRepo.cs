using BlogCommunity.Api.Data.Entities;

namespace BlogCommunity.Api.Data.Interfaces
{
    public interface IPostRepo
    {

        Task<List<Post>> GetAllAsync();
        Task<Post?> GetByIdAsync(int id);

        Task<List<Post>> GetByTitleAsync(string title);
        Task<List<Post>> GetByCategoryAsync(int categoryId);

        Task AddAsync(Post post);
        Task UpdateAsync(Post post);

        Task DeleteAsync(int id);



    }
}
