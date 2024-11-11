using BusinessLogic.DTO;
using BusinessLogic.DTO.Auth;

namespace BusinessLogic.Interfaces;

/// <summary>
/// Interface for user service. Defines methods for user management.
/// </summary>
public interface IUserService
{
    #region User management
    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="registrationDto"></param>
    /// <returns> <see langword="true"/> if the user was created successfully, <see langword="false"/> otherwise.</returns>
    Task<bool> CreateUserAsync(RegistrationDto registrationDto);

    /// <summary>
    /// Check if the entered password is correct.
    /// </summary>
    /// <param name="loginDto"></param>
    /// <returns> <see langword="true"/> if the password is correct, <see langword="false"/> otherwise.</returns>
    Task<bool> CheckUserPasswordAsync(LoginDto loginDto);

    /// <summary>
    /// Gets an access token by email.
    /// </summary>
    /// <param name="email"></param>
    /// <returns>Access token.</returns>
    Task<string> GetTokenByEmailAddressAsync(string email);

    /// <summary>
    /// Gets filtered, ordered and paginated collection of <see cref="UserDto"/> objects and total count of users.
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <param name="sortField"></param>
    /// <param name="sortOrder"></param>
    /// <returns> Collection of <see cref="UserDto"/> objects and total count of users.</returns>
    Task<(IEnumerable<UserDto>, int)> GetUsersAsync(string filter, int page, int pageSize, string sortField, string sortOrder);

    /// <summary>
    /// Gets user by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns> <see cref="UserDto"/> object.</returns>
    Task<UserDto> GetUserByIdAsync(string id);

    /// <summary>
    /// Gets user by email.
    /// </summary>
    /// <param name="email"></param>
    /// <returns> <see cref="UserDto"/> object.</returns>
    Task<UserDto> GetUserByEmailAsync(string email);

    /// <summary>
    /// Updates user.
    /// </summary>
    /// <param name="userDto"></param>
    /// <returns> <see langword="true"/> if the user was updated successfully, <see langword="false"/> otherwise.</returns>
    Task<bool> UpdateUserAsync(UserDto userDto);

    /// <summary>
    /// Deletes user by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns> <see langword="true"/> if the user was deleted successfully, <see langword="false"/> otherwise.</returns>
    Task<bool> DeleteUserAsync(string id);
    #endregion

    #region Role management
    /// <summary>
    /// Gets all roles.
    /// </summary>
    /// <returns> Collection of <see cref="RoleDto"/> objects.</returns>
    Task<IEnumerable<RoleDto>> GetRolesAsync();

    /// <summary>
    /// Gets roles by given filter with pagination and sorting.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns> Collection of <see cref="RoleDto"/> objects.</returns>
    Task<IEnumerable<string>> GetUserRolesByIdAsync(string userId);

    /// <summary>
    /// Gets all role names.
    /// </summary>
    /// <returns> Collection of role names.</returns>
    Task<IEnumerable<string>> GetRolesNamesAsync();

    /// <summary>
    /// Sets user role.
    /// </summary>
    /// <param name="editUserRolesDto"></param>
    /// <returns> <see langword="true"/> if the role was set successfully, <see langword="false"/> otherwise.</returns>
    Task<bool> SetUserRole(EditUserRolesDto editUserRolesDto);

    /// <summary>
    /// Removes user role.
    /// </summary>
    /// <param name="editUserRolesDto"></param>
    /// <returns> <see langword="true"/> if the role was removed successfully, <see langword="false"/> otherwise.</returns>
    Task<bool> RemoveRole(EditUserRolesDto editUserRolesDto);

    /// <summary>
    /// Gets user data by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns> <see cref="UserDataDto"/> object.</returns>
    Task<UserDataDto> GetUserDataByIdAsync(string id);
    #endregion
}
