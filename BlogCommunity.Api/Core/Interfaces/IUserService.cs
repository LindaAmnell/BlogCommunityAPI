using BlogCommunity.Api.Data.Entities;

namespace BlogCommunity.Api.Core.Interfaces
{
    public interface IUserService
    {

        Task<List<User>> GetAllUsersAsync();
        Task<User?> RegisterAsync(User user);
        Task<User?> LoginAsync(string userName, string password);
        Task<bool> UpdateUserAsync(int userId, User updatedUser);
        Task<bool> DeleteUserAsync(int userId);

    }
}
