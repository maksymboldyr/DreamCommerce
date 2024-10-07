using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities.Users
{
    public class Role : IdentityRole
    {
        [MaxLength(200)] // Limit description length to 200 characters
        public string? Description { get; set; }
    }
}
