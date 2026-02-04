using BlogCommunity.Api.Core.Interfaces;
using BlogCommunity.Api.Data.Entities;
using BlogCommunity.Api.Data.Interfaces;
using BlogCommunity.Api.Dtos.userDto;
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


        public async Task<User> GetUserById(int userId)
        {
            return await _userRepo.GetByIdAsync(userId);
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

        public async Task<bool> UpdateUserAsync(int userId, UpdateUserDto dto)
        {
            var user = await _userRepo.GetByIdAsync(userId);
            if (user == null)
                return false;

            if (!string.IsNullOrWhiteSpace(dto.UserName))
                user.UserName = dto.UserName;

            if (!string.IsNullOrWhiteSpace(dto.Email))
                user.Email = dto.Email;

            if (!string.IsNullOrWhiteSpace(dto.Password))
                user.Password = dto.Password;

            await _userRepo.UpdateUserAsync(user);
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
