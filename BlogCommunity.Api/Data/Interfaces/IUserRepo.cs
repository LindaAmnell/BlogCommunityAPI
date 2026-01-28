using BlogCommunity.Api.Data.Entities;

namespace BlogCommunity.Api.Data.Interfaces
{
    public interface IUserRepo
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByUserNameAsync(string userName);
        Task<User?> GetByUserEmailAsync(string email);

        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);


    }
}
