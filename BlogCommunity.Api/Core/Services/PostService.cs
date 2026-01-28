using BlogCommunity.Api.Core.Interfaces;
using BlogCommunity.Api.Data.Entities;
using BlogCommunity.Api.Data.Interfaces;

namespace BlogCommunity.Api.Core.Services
{
    public class PostService : IPostService
    {

        private readonly IPostRepo _postRepo;
        private readonly ICategoryRepo _categoryRepo;

        public PostService(IPostRepo postRepo, ICategoryRepo categoryRepo)
        {
            _postRepo = postRepo;
            _categoryRepo = categoryRepo;
        }

        public Task<bool> CreateAsync(Post post, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int postId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Post?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> SearchByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> SearchByTitleAsync(string title)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int postId, Post updatedPost, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
