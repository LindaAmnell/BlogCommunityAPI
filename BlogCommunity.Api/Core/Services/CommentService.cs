using BlogCommunity.Api.Core.Enum;
using BlogCommunity.Api.Core.Interfaces;
using BlogCommunity.Api.Data.Entities;
using BlogCommunity.Api.Data.Interfaces;
using BlogCommunity.Api.Dtos.CommentDto;

namespace BlogCommunity.Api.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepo _commentRepo;
        private readonly IPostRepo _postRepo;
        private readonly IUserRepo _userRepo;

        public CommentService(
            ICommentRepo commentRepo,
            IPostRepo postRepo,
            IUserRepo userRepo)
        {
            _commentRepo = commentRepo;
            _postRepo = postRepo;
            _userRepo = userRepo;
        }


        public async Task<CreateCommentResult> AddCommentAsync(
          int postId,
          CreateCommentDto dto,
          int userId)
        {
            var user = await _userRepo.GetByIdAsync(userId);
            if (user == null)
                return CreateCommentResult.UserNotFound;

            var post = await _postRepo.GetByIdAsync(postId);
            if (post == null)
                return CreateCommentResult.PostNotFound;

            if (post.UserID == userId)
                return CreateCommentResult.CannotCommentOwnPost;

            var comment = new Comment
            {
                Text = dto.Text,
                UserID = userId,
                PostID = postId
            };

            await _commentRepo.AddAsync(comment);
            return CreateCommentResult.Success;
        }

    }
}
