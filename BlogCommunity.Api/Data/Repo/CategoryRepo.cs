using BlogCommunity.Api.Data.Entities;
using BlogCommunity.Api.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogCommunity.Api.Data.Repo
{
    public class CategoryRepo : ICategoryRepo
    {

        private readonly CommunityDbContext _context;

        public CategoryRepo(CommunityDbContext context)
        {
            _context = context;
        }

        public async Task AddCategoryAsync(Category category)
        {
                _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
    }
}
