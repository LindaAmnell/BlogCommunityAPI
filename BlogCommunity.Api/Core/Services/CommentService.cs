using BlogCommunity.Api.Core.Interfaces;
using BlogCommunity.Api.Data.Entities;
using BlogCommunity.Api.Data.Interfaces;

namespace BlogCommunity.Api.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepo _comentRepo;
        private readonly IPostRepo _postRepo;

        public CommentService(ICommentRepo comentRepo, IPostRepo postRepo)
        {
            _comentRepo = comentRepo;
            _postRepo = postRepo;
        }

        public Task<bool> AddCommentAsync(Comment comment, int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
