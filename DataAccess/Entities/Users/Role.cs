using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entities.Users
{
    public class Role : IdentityRole
    {
        public string? Description { get; set; }
    }
}
