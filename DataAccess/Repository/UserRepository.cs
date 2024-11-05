using DataAccess.Entities.Users;
using DataAccess.Exceptions;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repository;

/// <summary>
/// Repository for user entities. Implements <seealso cref="IUserRepository"/>.
/// </summary>
public class UserRepository(UserManager<User> userManager, RoleManager<Role> roleManager) : IUserRepository
{
    /// <summary>
    /// Inserts a user entity to the database.
    /// </summary>
    /// <param name="user"></param>
    /// <returns><see langword="true"/> if the user was created successfully, otherwise <see langword="false"/>.</returns>
    public async Task<bool> CreateUserAsync(User user)
    {
        var result = await userManager.CreateAsync(user);
        return result.Succeeded;
    }

    /// <summary>
    /// Deletes a user entity from the database.
    /// </summary>
    /// <param name="id"></param>
    /// <returns><see langword="true"/> if the user was deleted successfully, otherwise <see langword="false"/>.</returns>
    public async Task<bool> DeleteUserAsync(string id)
    {
        var user = await ValidateUserExistsAsync(id);
        var result = await userManager.DeleteAsync(user);
        return result.Succeeded;
    }

    /// <summary>
    /// Gets all roles from the database.
    /// </summary>
    /// <returns>Collection of <seealso cref="Role"/> entities.</returns>
    public async Task<IEnumerable<Role>> GetRolesAsync()
    {
        return await roleManager.Roles.ToListAsync();
    }

    /// <summary>
    /// Gets all users from the database.
    /// </summary>
    /// <param name="email"></param>
    /// <returns>Collection of <seealso cref="User"/> entities.</returns>
    /// <exception cref="UserNotFoundException"></exception>
    public async Task<User> GetUserByEmailAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
        {
            throw new UserNotFoundException(email);
        }
        return user;
    }

    /// <summary>
    /// Gets a user entity by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns><seealso cref="User"/> entity.</returns>
    public async Task<User> GetUserByIdAsync(string id)
    {
        return await ValidateUserExistsAsync(id);
    }

    /// <summary>
    /// Gets roles of a user by their ID.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns> Collection of role names.</returns>
    public async Task<IEnumerable<string>> GetUserRolesByIdAsync(string userId)
    {
        var user = await ValidateUserExistsAsync(userId);
        return await userManager.GetRolesAsync(user);
    }

    /// <summary>
    /// Gets all users from the database.
    /// </summary>
    /// <returns>Collection of <seealso cref="User"/> entities.</returns>
    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        IQueryable<User> query = userManager.Users;

        return await query.ToListAsync();
    }

    /// <summary>
    /// Removes a role from a user.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="roleName"></param>
    /// <returns><see langword="true"/> if the role was removed successfully, otherwise <see langword="false"/>.</returns>
    /// <exception cref="RoleNotFoundException"></exception>
    public async Task<bool> RemoveRole(string userId, string roleName)
    {
        var user = await ValidateUserExistsAsync(userId);
        var role = await roleManager.FindByNameAsync(roleName);
        if (role == null)
        {
            throw new RoleNotFoundException(roleName);
        }
        var result = await userManager.RemoveFromRoleAsync(user, roleName);
        return result.Succeeded;
    }

    /// <summary>
    /// Sets a role to a user.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="roleName"></param>
    /// <returns><see langword="true"/> if the role was set successfully, otherwise <see langword="false"/>.</returns>
    /// <exception cref="RoleNotFoundException"></exception>
    public async Task<bool> SetRole(string userId, string roleName)
    {
        var user = await ValidateUserExistsAsync(userId);
        var role = await roleManager.FindByNameAsync(roleName);
        if (role == null)
        {
            throw new RoleNotFoundException(roleName);
        }
        var result = await userManager.AddToRoleAsync(user, roleName);
        return result.Succeeded;
    }

    /// <summary>
    /// Updates a user entity in the database.
    /// </summary>
    /// <param name="user"></param>
    /// <returns><see langword="true"/> if the user was updated successfully, otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<bool> UpdateUserAsync(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User cannot be null");
        }

        var userToUpdate = await ValidateUserExistsAsync(user.Id);
        userToUpdate.UserName ??= user.UserName;
        userToUpdate.Email ??= user.Email;
        userToUpdate.FirstName ??= user.FirstName;
        userToUpdate.LastName ??= user.LastName;
        userToUpdate.PhoneNumber ??= user.PhoneNumber;
        userToUpdate.Address ??= user.Address;

        var result = await userManager.UpdateAsync(userToUpdate);
        return result.Succeeded;
    }

    /// <summary>
    /// Validates if a user exists in the database.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns><seealso cref="User"/> entity.</returns>
    /// <exception cref="UserNotFoundException"></exception>
    private async Task<User> ValidateUserExistsAsync(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new UserNotFoundException(userId);
        }
        return user;
    }
}
