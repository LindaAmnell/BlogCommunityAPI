using BlogCommunity.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogCommunity.Api.Data
{
    public class CommunityDbContext :DbContext
    {

        public CommunityDbContext(DbContextOptions<CommunityDbContext> options)
         : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}

