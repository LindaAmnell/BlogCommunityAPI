using BlogCommunity.Api.Data.Entities;

namespace BlogCommunity.Api.Data.Interfaces
{
    public interface ICategoryRepo
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);

        Task AddCategoryAsync(Category category);
    }
}
