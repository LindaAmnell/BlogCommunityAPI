using BlogCommunity.Api.Data.Entities;
using BlogCommunity.Api.Data.Interfaces;

namespace BlogCommunity.Api.Data.Repo
{
    public class CategoryRepo : ICategoryRepo
    {

        private readonly CommunityDbContext _context;

        public CategoryRepo(CommunityDbContext context)
        {
            _context = context;
        }

        public Task AddCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
