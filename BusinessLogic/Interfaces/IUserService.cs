using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(RegistrationModel userModel);
        Task<bool> CheckUserPasswordAsync(LoginModel userModel);
        Task<string> GetTokenByEmailAddressAsync(string email);
        Task<LoginModel> GetUserByIdAsync(string id);
        Task<LoginModel> GetUserByEmailAsync(string email);
        Task<bool> UpdateUserAsync(LoginModel userModel);
        Task<bool> DeleteUserAsync(string id);
    }
}
