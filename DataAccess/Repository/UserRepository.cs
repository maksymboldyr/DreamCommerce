using DataAccess.Entities.Users;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            var user = await _userManager.FindByIdAsync(id);

            if (user == null) {
                throw new ArgumentException("User not found");
            }
            
            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded) {
                throw new ArgumentException("User not deleted");
            }

            return result.Succeeded;
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) {
                throw new ArgumentException("User not found");
            }

            return user;
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null) {
                throw new ArgumentException("User not found");
            }

            return user;
        }

        public async Task<IEnumerable<string>> GetUserRolesByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null) {
                throw new ArgumentException("User not found");
            }

            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IEnumerable<User>> GetUsersAsync(
            Expression<Func<User, bool>> filter = null,
            Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null,
            string includeProperties = "")
        {
            var query = _userManager.Users;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<bool> RemoveRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null) {
                throw new ArgumentException("User not found");
            }

            var role = await _roleManager.FindByNameAsync(roleName);

            if (role == null) {
                throw new ArgumentException("Role not found");
            }

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);

            if (!result.Succeeded) {
                throw new ArgumentException("Role not removed");
            }

            return true;
        }

        public async Task<bool> SetRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null) {
                throw new ArgumentException("User not found");
            }

            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null) {
                throw new ArgumentException("Role not found");
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);

            if (!result.Succeeded) {
                throw new ArgumentException("Role not added");
            }

            return true;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            if (user == null) {
                throw new ArgumentException("User not found");
            }

            var userToUpdate = await _userManager.FindByIdAsync(user.Id);

            if (userToUpdate == null) {
                throw new ArgumentException("User not found");
            }

            var result = await _userManager.UpdateAsync(userToUpdate);
            return result.Succeeded;
        }
    }
}
