using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Identity;
using DataAccess.Entities.Users;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, UserManager<User> userManager, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<bool> CheckUserPasswordAsync(LoginModel userModel)
        {
            var user = await _userRepository.GetUserByEmailAsync(userModel.Email);
            return await _userManager.CheckPasswordAsync(user, userModel.Password);
        }


        public async Task<bool> CreateUserAsync(RegistrationModel userModel)
        {
            var userExists = await _userRepository.GetUserByEmailAsync(userModel.Email);
            if (userExists != null)
            {
                return false;
            }

            var user = new User { UserName = userModel.Email, Email = userModel.Email};
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userModel.Password);
            return await _userRepository.CreateUserAsync(user);
        }

        public Task<bool> DeleteUserAsync(string id)
        {
            return _userRepository.DeleteUserAsync(id);
        }

        public async Task<string> GetTokenByEmailAddressAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            string token = GenerateToken(authClaims);
            return token;
        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<LoginModel> GetUserByEmailAsync(string email)
        {
            var  user = await _userRepository.GetUserByEmailAsync(email);
            var userModel = new LoginModel { Email = user.Email };
            return userModel;
        }

        public async Task<LoginModel> GetUserByIdAsync(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            var userModel = new LoginModel { Email = user.Email };
            return userModel;
        }

        public Task<bool> UpdateUserAsync(LoginModel userModel)
        {
            var user = new User { UserName = userModel.Email, Email = userModel.Email };
            return _userRepository.UpdateUserAsync(user);
        }
    }
}
