using BlogCommunity.Api.Data.Entities;

namespace BlogCommunity.Api.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task AddCategoryAsync(Category category);

    }
}
