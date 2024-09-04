using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(UserModel user);
        Task<bool> CheckUserPasswordAsync(UserModel user);
        Task<UserModel> GetUserByIdAsync(string id);
        Task<UserModel> GetUserByEmailAsync(string email);
        Task<bool> UpdateUserAsync(UserModel user);
        Task<bool> DeleteUserAsync(string id);
    }
}
