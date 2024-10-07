using DataAccess.Entities.Users;
using System.Linq.Expressions;

namespace DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(string id);
        Task<User> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(string id);
        
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<IEnumerable<string>> GetUserRolesByIdAsync(string userId);
        Task<bool> SetRole(string userId, string roleName);
        Task<bool> RemoveRole(string userId, string roleName);
    }
}
