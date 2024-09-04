using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UserService(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<bool> CheckUserPasswordAsync(UserModel userModel)
        {
            var user = await _userRepository.GetUserByEmailAsync(userModel.Email);
            return await _userManager.CheckPasswordAsync(user, userModel.Password);
        }

        public async Task<bool> CreateUserAsync(UserModel model)
        {
            var user = new User { UserName = model.Email, Email = model.Email};
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            return await _userRepository.CreateUserAsync(user);
        }

        public Task<bool> DeleteUserAsync(string id)
        {
            return _userRepository.DeleteUserAsync(id);
        }

        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            var  user = await _userRepository.GetUserByEmailAsync(email);
            var userModel = new UserModel { Email = user.Email };
            return userModel;
        }

        public async Task<UserModel> GetUserByIdAsync(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            var userModel = new UserModel { Email = user.Email };
            return userModel;
        }

        public Task<bool> UpdateUserAsync(UserModel model)
        {
            var user = new User { UserName = model.Email, Email = model.Email };
            return _userRepository.UpdateUserAsync(user);
        }
    }
}
