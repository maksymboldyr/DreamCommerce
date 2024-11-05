using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities.Users
{
    /// <summary>
    /// Represents a user in the system. Inherits from <seealso cref="IdentityUser"/> to use the Identity API.
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// First name of the user. Limited to 50 characters.
        /// </summary>
        [MaxLength(50)]
        public string? FirstName { get; set; }

        /// <summary>
        /// Last name (surname) of the user. Limited to 50 characters.
        /// </summary>
        [MaxLength(50)]
        public string? LastName { get; set; }

        /// <summary>
        /// Represents foreign key for the <seealso cref="Address"/>.
        /// </summary>
        [ForeignKey("Address")]
        public string? AddressId { get; set; }

        /// <summary>
        /// Navigation property for the <see cref="Entities.Address"/> entity.
        /// </summary>
        public Address? Address { get; set; }

        /// <summary>
        /// Navigation property for the <seealso cref="Entities.Cart"/> entity.
        /// </summary>
        public virtual Cart? Cart { get; set; }

        /// <summary>
        /// Navigation property for the <seealso cref="Entities.Order"/> entity.
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
