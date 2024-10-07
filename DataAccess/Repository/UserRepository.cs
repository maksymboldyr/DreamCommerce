using DataAccess.Entities.Users;
using DataAccess.Exceptions;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserRepository(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            var result = await _userManager.CreateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var user = await ValidateUserExistsAsync(id);
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new UserNotFoundException(email);
            }
            return user;
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await ValidateUserExistsAsync(id);
        }

        public async Task<IEnumerable<string>> GetUserRolesByIdAsync(string userId)
        {
            var user = await ValidateUserExistsAsync(userId);
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            IQueryable<User> query = _userManager.Users;

            return await query.ToListAsync();
        }

        public async Task<bool> RemoveRole(string userId, string roleName)
        {
            var user = await ValidateUserExistsAsync(userId);
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                throw new RoleNotFoundException(roleName);
            }
            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            return result.Succeeded;
        }

        public async Task<bool> SetRole(string userId, string roleName)
        {
            var user = await ValidateUserExistsAsync(userId);
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                throw new RoleNotFoundException(roleName);
            }
            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded;
        }

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

            var result = await _userManager.UpdateAsync(userToUpdate);
            return result.Succeeded;
        }

        private async Task<User> ValidateUserExistsAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new UserNotFoundException(userId);
            }
            return user;
        }
    }
}
