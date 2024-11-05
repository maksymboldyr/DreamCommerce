using BusinessLogic.DTO;
using BusinessLogic.DTO.Auth;
using BusinessLogic.Interfaces;
using DataAccess.Entities.Users;
using DataAccess.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BusinessLogic.Services.Domain
{
    public class UserService(
        IUserRepository userRepository,
        FilterBuilderService filterBuilder,
        SortingService<User> sortingService,
        UserManager<User> userManager,
        IConfiguration configuration) : IUserService
    {
        public async Task<UserDataDto> GetUserDataByIdAsync(string id)
        {
            var user = await userRepository.GetUserByIdAsync(id);
            return user.Adapt<UserDataDto>();
        }

        public async Task<bool> CreateUserAsync(RegistrationDTO userModel)
        {
            var user = userModel.Adapt<User>();
            return await userRepository.CreateUserAsync(user);
        }

        public async Task<bool> CheckUserPasswordAsync(LoginDTO userModel)
        {
            var user = await userRepository.GetUserByEmailAsync(userModel.Email);
            return await userManager.CheckPasswordAsync(user, userModel.Password);
        }

        public async Task<string> GetTokenByEmailAddressAsync(string email)
        {
            var user = await userRepository.GetUserByEmailAsync(email);
            var userRoles = await userManager.GetRolesAsync(user);
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
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = configuration["JWT:ValidIssuer"],
                Audience = configuration["JWT:ValidAudience"],
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<(IEnumerable<UserDTO>, int)> GetUsersAsync(string filter, int page, int pageSize, string sortField, string sortOrder)
        {
            var filterExpression = filterBuilder.BuildFilter<UserDTO>(filter);
            var sortExpression = sortingService.GetSortExpression(sortField, sortOrder);

            var users = await userRepository.GetUsersAsync();

            var userDTOs = new List<UserDTO>();

            foreach (var user in users)
            {
                var userDTO = user.Adapt<UserDTO>();
                userDTO.Roles = await GetUserRolesByIdAsync(user.Id);
                userDTOs.Add(userDTO);
            }

            var filteredDTOs = userDTOs
                .Where(u => filterExpression.Compile().Invoke(u))
                .OrderBy(u => sortExpression);

            var totalUsers = filteredDTOs.Count();

            var pagedUserDTOs = filteredDTOs
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return (pagedUserDTOs, totalUsers);
        }

        public async Task<UserDTO> GetUserByIdAsync(string id)
        {
            var user = await userRepository.GetUserByIdAsync(id);
            return user.Adapt<UserDTO>();
        }

        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            var user = await userRepository.GetUserByEmailAsync(email);
            return user.Adapt<UserDTO>();
        }

        public async Task<bool> UpdateUserAsync(UserDTO userModel)
        {
            var user = userModel.Adapt<User>();
            return await userRepository.UpdateUserAsync(user);
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            return await userRepository.DeleteUserAsync(id);
        }

        public async Task<IEnumerable<RoleDTO>> GetRolesAsync()
        {
            var roles = await userRepository.GetRolesAsync();
            return roles.Adapt<IEnumerable<RoleDTO>>();
        }

        public async Task<IEnumerable<string>> GetUserRolesByIdAsync(string userId)
        {
            return await userRepository.GetUserRolesByIdAsync(userId);
        }

        public async Task<IEnumerable<string>> GetRolesNamesAsync()
        {
            var roles = await userRepository.GetRolesAsync();
            return roles.Select(r => r.Name);
        }

        public async Task<bool> SetUserRole(EditUserRolesDTO editUserRolesDTO)
        {
            return await userRepository.SetRole(editUserRolesDTO.UserId, editUserRolesDTO.RoleName);
        }

        public async Task<bool> RemoveRole(EditUserRolesDTO editUserRolesDTO)
        {
            return await userRepository.RemoveRole(editUserRolesDTO.UserId, editUserRolesDTO.RoleName);
        }
    }
}
