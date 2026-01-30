using BlogCommunity.Api.Core.Interfaces;
using BlogCommunity.Api.Data.Entities;
using BlogCommunity.Api.Data.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace BlogCommunity.Api.Core.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
           return await _userRepo.GetAllUsersAsync(); 
        }

        public async Task<User?> LoginAsync(string userName, string password)
        {
            var user = await _userRepo.GetByUserNameAsync(userName);
            if (user == null) return null;

            if (user.Password != password) return null;
                
            return user;
                    
         }

        public async Task<User?> RegisterAsync(User user)
        {
            var existing = await _userRepo.GetByUserNameAsync(user.UserName);
            if (existing != null) return null;

            await _userRepo.AddUserAsync(user);
            return user;

        }

        public async Task<bool> UpdateUserAsync(int userId, User updatedUser)
        {
            var existingUser = await _userRepo.GetByIdAsync(userId);

            if (existingUser == null) return false;

            existingUser.UserName = updatedUser.UserName;
            existingUser.Password = updatedUser.Password;
            existingUser.Email = updatedUser.Email;

            await  _userRepo.UpdateUserAsync(existingUser);
            return true;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _userRepo.GetByIdAsync(userId);
            if (user == null) return false;

            await _userRepo.DeleteUserAsync(userId);
            return true;
        }
    }
}
