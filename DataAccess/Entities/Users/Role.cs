using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities.Users;

/// <summary>
/// Represents a user role in the system. Inherits from <seealso cref="IdentityRole"/> to use the Identity API.
/// </summary>
public class Role : IdentityRole
{
    /// <summary>
    /// Description of the role. Limited to 200 characters.
    /// </summary>
    [MaxLength(200)]
    public string? Description { get; set; }
}
