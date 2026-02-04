using BlogCommunity.Api.Core.Enum;
using BlogCommunity.Api.Core.Interfaces;
using BlogCommunity.Api.Data.Entities;
using BlogCommunity.Api.Data.Interfaces;
using BlogCommunity.Api.Data.Repo;
using BlogCommunity.Api.Dtos.postDto;

namespace BlogCommunity.Api.Core.Services
{
    public class PostService : IPostService
    {

        private readonly IPostRepo _postRepo;
        private readonly ICategoryRepo _categoryRepo;
        private readonly IUserRepo _userRepo;

        public PostService( IPostRepo postRepo,ICategoryRepo categoryRepo, IUserRepo userRepo)
        {
            _postRepo = postRepo;
            _categoryRepo = categoryRepo;
            _userRepo = userRepo;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _postRepo.GetAllAsync();
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            return await _postRepo.GetByIdAsync(id);
        }
        public async Task<List<Post>> SearchByTitleAsync(string title)
        {
            return await _postRepo.GetByTitleAsync(title);
        }

        public async Task<List<Post>> SearchByCategoryAsync(int categoryId)
        {
            return await _postRepo.GetByCategoryAsync(categoryId);
        }

        public async Task<CreatePostResult> CreateAsync(Post post, int userId)
        {
            var user = await _userRepo.GetByIdAsync(userId);
            if (user == null)
                return CreatePostResult.UserNotFound;

            var category = await _categoryRepo.GetByIdAsync(post.CategoryID);
            if (category == null)
                return CreatePostResult.CategoryNotFound;

            post.UserID = userId;
            await _postRepo.AddAsync(post);

            return CreatePostResult.Success;
        }

        public async Task<bool> UpdateAsync(int postId, UpdatePostDto dto, int userId)
        {
            var existingPost = await _postRepo.GetByIdAsync(postId);
            if (existingPost == null)
                return false;

            if (existingPost.UserID != userId)
                return false;

            if (!string.IsNullOrWhiteSpace(dto.Title))
                existingPost.Title = dto.Title;

            if (!string.IsNullOrWhiteSpace(dto.Text))
                existingPost.Text = dto.Text;

            if (dto.CategoryID.HasValue)
                existingPost.CategoryID = dto.CategoryID.Value;

            await _postRepo.UpdateAsync(existingPost);
            return true;

        }

        public async Task<bool> DeleteAsync(int postId, int userID)
        {

            var post = await _postRepo.GetByIdAsync(postId);
            if (post == null) 
            {
                return false;
            }

            if (post.UserID != userID) 
            {
                return false;
            }

            await _postRepo.DeleteAsync(postId);
            return true;

        }

      
    }
}
