using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using DataAccess.Entities.Users;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using BusinessLogic.DTO;
using System.Linq.Expressions;

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

        public async Task<bool> CheckUserPasswordAsync(LoginDTO userModel)
        {
            var user = await _userRepository.GetUserByEmailAsync(userModel.Email);
            return await _userManager.CheckPasswordAsync(user, userModel.Password);
        }

        public async Task<bool> CreateUserAsync(RegistrationDTO userModel)
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
               new Claim("id", user.Id),
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

        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            var  user = await _userRepository.GetUserByEmailAsync(email);
            var userModel = new UserDTO
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
            return userModel;
        }

        public async Task<UserDTO> GetUserByIdAsync(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var userModel = new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Roles = await _userRepository.GetUserRolesByIdAsync(id)
            };

            return userModel;
        }

        public async Task<bool> UpdateUserAsync(UserDTO userModel)
        {
            var user = await _userRepository.GetUserByIdAsync(userModel.Id);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            user.Email ??= userModel.Email;
            user.PhoneNumber ??= userModel.PhoneNumber;
            user.Address ??= userModel.Address;
            user.FirstName ??= userModel.FirstName;
            user.LastName ??= userModel.LastName;

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                if (!userModel.Roles.Contains(userRole))
                {
                    await _userRepository.RemoveRole(user.Id, userRole);
                }
            }

            foreach (var role in userModel.Roles)
            {
                if (!userRoles.Contains(role))
                {
                    await _userRepository.SetRole(user.Id, role);
                }
            }
            
            return await _userRepository.UpdateUserAsync(user);
        }

        public async Task<IEnumerable<RoleDTO>> GetRolesAsync()
        {
            var roles = await _userRepository.GetRolesAsync();

            return roles.Select(r => new RoleDTO
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            });
        }

        public async Task<IEnumerable<string>> GetRolesNamesAsync()
        {
            var roles = await _userRepository.GetRolesAsync();

            return roles.Select(r => r.Name);
        }

        public async Task<IEnumerable<string>> GetUserRolesByIdAsync(string userId)
        {
            return await _userRepository.GetUserRolesByIdAsync(userId);
        }

        public async Task<(IEnumerable<UserDTO>, int)> GetUsersAsync(int page, int pageSize, string sortField, string sortOrder)
        {
            Func<IQueryable<User>, IOrderedQueryable<User>> orderBy;

            switch (sortOrder)
            {
                case "asc":
                    orderBy = u => u.OrderBy(GetSortExpression(sortField));
                    break;
                case "desc":
                    orderBy = u => u.OrderByDescending(GetSortExpression(sortField));
                    break;
                default:
                    orderBy = u => u.OrderBy(GetSortExpression(sortField));
                    break;
            }

            var users = await _userRepository.GetUsersAsync(orderBy: orderBy);

            var usersCount = users.Count();

            var userModels = users.Select(u => new UserDTO
            {
                Id = u.Id,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Address = u.Address,
                FirstName = u.FirstName,
                LastName = u.LastName,
            }).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            foreach (var userModel in userModels)
            {
                if (userModel.Id != null)
                {
                    var roles = await _userRepository.GetUserRolesByIdAsync(userModel.Id);
                    userModel.Roles = roles;
                }
            }

            return (userModels, usersCount);
        }

        private Expression<Func<User, object>> GetSortExpression(string sortField)
        {
            switch (sortField)
            {
                case "id":
                    return u => u.Id;
                case "email":
                    return u => u.Email;
                case "phoneNumber":
                    return u => u.PhoneNumber;
                case "address":
                    return u => u.Address;
                case "firstName":
                    return u => u.FirstName;
                case "lastName":
                    return u => u.LastName;
                default:
                    return u => u.Id;
            }
        }

        public Task<bool> SetUserRole(EditUserRolesDTO editUserRolesDTO)
        {
            return _userRepository.SetRole(editUserRolesDTO.UserId, editUserRolesDTO.RoleName);
        }

        public Task<bool> RemoveRole(EditUserRolesDTO editUserRolesDTO)
        {
            return _userRepository.RemoveRole(editUserRolesDTO.UserId, editUserRolesDTO.RoleName);
        }
    }
}
