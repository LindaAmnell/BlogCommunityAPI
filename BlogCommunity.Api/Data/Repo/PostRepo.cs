using BlogCommunity.Api.Data.Entities;
using BlogCommunity.Api.Data.Interfaces;

namespace BlogCommunity.Api.Data.Repo
{
    public class PostRepo : IPostRepo
    {

        private readonly CommunityDbContext _context;

        public PostRepo(CommunityDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<Post?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetByTitleAsync(string title)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
