using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            var result = await _userManager.CreateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            
            var result = await _userManager.DeleteAsync(user);

            return result.Succeeded;
        }
        

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user;
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            return user;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var userToUpdate = await _userManager.FindByEmailAsync(user.Email);
            var result = await _userManager.UpdateAsync(userToUpdate);
            return result.Succeeded;
        }
    }
}
