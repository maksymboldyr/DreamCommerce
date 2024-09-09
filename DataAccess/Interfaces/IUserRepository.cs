using DataAccess.Entities.Users;

namespace DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(string id);
        Task<User> GetUserByEmailAsync(string email);
        Task<Role> GetUserRoleById(string id);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(string id);
    }
}
