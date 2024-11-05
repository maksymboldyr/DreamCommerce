using DataAccess.Entities.Users;
using System.Linq.Expressions;

namespace DataAccess.Interfaces;

/// <summary>
/// Interface for a user repository.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Inserts a user entity to the database.
    /// </summary>
    /// <param name="user"></param>
    /// <returns><see langword="true"/> if the user was created successfully, otherwise <see langword="false"/>.</returns>
    Task<bool> CreateUserAsync(User user);

    /// <summary>
    /// Gets a user entity by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns><seealso cref="User"/> entity.</returns>
    Task<User> GetUserByIdAsync(string id);

    /// <summary>
    /// Gets a user entity by its email.
    /// </summary>
    /// <param name="email"></param>
    /// <returns><seealso cref="User"/> entity.</returns>
    /// <exception cref="UserNotFoundException"></exception>
    Task<User> GetUserByEmailAsync(string email);

    /// <summary>
    /// Gets all users from the database.
    /// </summary>
    /// <returns>Collection of <seealso cref="User"/> entities.</returns>
    Task<IEnumerable<User>> GetUsersAsync();

    /// <summary>
    /// Updates a user entity in the database.
    /// </summary>
    /// <param name="user"></param>
    /// <returns><see langword="true"/> if the user was updated successfully, otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    Task<bool> UpdateUserAsync(User user);

    /// <summary>
    /// Deletes a user entity from the database.
    /// </summary>
    /// <param name="id"></param>
    /// <returns><see langword="true"/> if the user was deleted successfully, otherwise <see langword="false"/>.</returns>
    Task<bool> DeleteUserAsync(string id);

    /// <summary>
    /// Gets all roles from the database.
    /// </summary>
    /// <returns>Collection of <seealso cref="Role"/> entities.</returns>
    Task<IEnumerable<Role>> GetRolesAsync();

    /// <summary>
    /// Gets roles of a user by their ID.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns> Collection of role names.</returns>
    Task<IEnumerable<string>> GetUserRolesByIdAsync(string userId);

    /// <summary>
    /// Sets a role to a user.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="roleName"></param>
    /// <returns><see langword="true"/> if the role was set successfully, otherwise <see langword="false"/>.</returns>
    /// <exception cref="RoleNotFoundException"></exception>
    Task<bool> SetRole(string userId, string roleName);

    /// <summary>
    /// Removes a role from a user.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="roleName"></param>
    /// <returns><see langword="true"/> if the role was removed successfully, otherwise <see langword="false"/>.</returns>
    /// <exception cref="RoleNotFoundException"></exception>
    Task<bool> RemoveRole(string userId, string roleName);
}
