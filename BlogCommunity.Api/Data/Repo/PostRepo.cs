using BlogCommunity.Api.Data.Entities;
using BlogCommunity.Api.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogCommunity.Api.Data.Repo
{
    public class PostRepo : IPostRepo
    {

        private readonly CommunityDbContext _context;

        public PostRepo(CommunityDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return;

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<List<Post>> GetByCategoryAsync(int categoryId)
        {
            return await _context.Posts
                 .Where(p => p.CategoryID == categoryId)
                 .ToListAsync();
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<List<Post>> GetByTitleAsync(string title)
        {
            return await _context.Posts
                  .Where(p => p.Title.Contains(title))
                  .ToListAsync();

        }

        public async Task UpdateAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }
    }
}
