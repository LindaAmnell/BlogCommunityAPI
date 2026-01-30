using BlogCommunity.Api.Data.Entities;
using BlogCommunity.Api.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogCommunity.Api.Data.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly CommunityDbContext _context;

        public UserRepo(CommunityDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
        await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
           var user = await _context.Users.FindAsync(id);
            if (user == null) return;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetByUserEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task<User?> GetByUserNameAsync(string userName)
        {
            return _context.Users.FirstOrDefaultAsync( u => u.UserName == userName);
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
