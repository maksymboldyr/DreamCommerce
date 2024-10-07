using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities.Users
{
    public class User : IdentityUser
    {
        [MaxLength(50)] // Limit first name length to 50 characters
        public string? FirstName { get; set; }

        [MaxLength(50)] // Limit last name length to 50 characters
        public string? LastName { get; set; }

        [ForeignKey("Address")]
        public string? AddressId { get; set; }

        public Address? Address { get; set; }

        public virtual Cart? Cart { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
