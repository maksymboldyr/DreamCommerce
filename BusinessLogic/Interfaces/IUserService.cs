using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(RegistrationDTO userModel);
        Task<bool> CheckUserPasswordAsync(LoginDTO userModel);
        Task<string> GetTokenByEmailAddressAsync(string email);
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<LoginDTO> GetUserByIdAsync(string id);
        Task<LoginDTO> GetUserByEmailAsync(string email);
        Task<bool> UpdateUserAsync(LoginDTO userModel);
        Task<bool> DeleteUserAsync(string id);

        Task<IEnumerable<RoleDTO>> GetRolesAsync();
        Task<IEnumerable<string>> GetUserRolesByIdAsync(string userId);
        Task<IEnumerable<string>> GetRolesNamesAsync();
        Task<bool> SetUserRole(EditUserRolesDTO editUserRolesDTO);
        Task<bool> RemoveRole(EditUserRolesDTO editUserRolesDTO);
    }
}
