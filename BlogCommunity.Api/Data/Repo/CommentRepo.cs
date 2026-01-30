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

        public async Task AddAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }
    }
}
