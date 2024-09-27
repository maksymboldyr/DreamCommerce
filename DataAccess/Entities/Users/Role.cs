using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entities.Users
{
    public class Role : IdentityRole
    {
        public string? Description { get; set; }

        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
