using DataAccess.Entities.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

/// <summary>
/// Order status enum.
/// </summary>
public enum OrderStatus
{
    New,
    Confirmed,
    Shipped,
    Delivered,
    Cancelled,
    Completed
}

/// <summary>
/// Represents general order entity.
/// </summary>
public class Order : BaseEntity
{
    /// <summary>
    /// Foreign key to the <seealso cref="User"/> entity. Is required.
    /// </summary>
    [Required]
    [ForeignKey("User")]
    public string UserId { get; set; }

    /// <summary>
    /// Foreign key to the <seealso cref="Address"/> entity. Is required.
    /// </summary>
    [Required]
    [ForeignKey("Address")]
    public string AddressId { get; set; }

    /// <summary>
    /// Order status. Is required.
    /// </summary>
    [Required]
    public OrderStatus Status { get; set; }

    /// <summary>
    /// Total price of items in the order. Is required. Precision is 18, scale is 2.
    /// </summary>
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }

    /// <summary>
    /// Navigation property to the <seealso cref="Entities.Users.User"/> entity.
    /// </summary>
    public User User { get; set; }
    
    /// <summary>
    /// Navigation property to the <seealso cref="Entities.Address"/> entity.
    /// </summary>
    public Address Address { get; set; }

    /// <summary>
    /// Navigation property to related <seealso cref="Entities.OrderDetail"/> entities.
    /// </summary>
    public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
