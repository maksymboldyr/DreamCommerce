using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

/// <summary>
/// Represents an order detail. Contains information about a product in an order, such as its quantity, total price, etc.
/// </summary>
public class OrderDetail : BaseEntity
{
    /// <summary>
    /// Foreign key to the <seealso cref="Order"/> entity. Is required.
    /// </summary>
    [Required]
    [ForeignKey("Order")]
    public string OrderId { get; set; }

    /// <summary>
    /// Navigation property to the <seealso cref="Entities.Order"/> entity.
    /// </summary>
    public Order Order { get; set; }

    /// <summary>
    /// Foreign key to the <seealso cref="Product"/> entity. Is required.
    /// </summary>
    [Required]
    [ForeignKey("Product")]
    public string ProductId { get; set; }

    /// <summary>
    /// Navigation property to the <seealso cref="Entities.Product"/> entity.
    /// </summary>
    public Product Product { get; set; }

    /// <summary>
    /// Quantity of the product in the order. Must be at least 1.
    /// </summary>
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
    public int Quantity { get; set; }

    /// <summary>
    /// Total price of the product in the order. Is required. Precision is 18, scale is 2.
    /// </summary>
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }
}
