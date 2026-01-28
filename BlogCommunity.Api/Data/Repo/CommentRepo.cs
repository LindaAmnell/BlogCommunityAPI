using BlogCommunity.Api.Data.Entities;
using BlogCommunity.Api.Data.Interfaces;

namespace BlogCommunity.Api.Data.Repo
{
    public class CommentRepo : ICommentRepo
    {
        private readonly CommunityDbContext _context;

        public CommentRepo(CommunityDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
