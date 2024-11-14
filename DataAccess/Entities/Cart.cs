using DataAccess.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

/// <summary>
/// Represents a cart entity.
/// </summary>
public class Cart: BaseEntity
{
    /// <summary>
    /// Foreign key to the <seealso cref="User"/> entity.
    /// </summary>
    [ForeignKey("User")]
    public string UserId { get; set; }

    /// <summary>
    /// Navigation property to the <seealso cref="Entities.Users.User"/> entity.
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Navigation property to related <seealso cref="CartItem"/> entities.
    /// </summary>
    public List<CartItem> CartItems { get; set; } = new List<CartItem>();
}
