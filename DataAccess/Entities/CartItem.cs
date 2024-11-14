using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

/// <summary>
/// Represents an item in a <seealso cref="Entities.Cart"/>.
/// </summary>
public class CartItem: BaseEntity
{
    /// <summary>
    /// Foreign key to the <seealso cref="Product"/> entity.
    /// </summary>
    [ForeignKey("Product")]
    public string ProductId { get; set; }

    /// <summary>
    /// Navigation property to the <seealso cref="Entities.Product"/> entity.
    /// </summary>
    public Product Product { get; set; }

    /// <summary>
    /// Quantity of the product in the cart.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Foreign key to the <seealso cref="Cart"/> entity.
    /// </summary>
    [ForeignKey("Cart")]
    public string CartId { get; set; }

    /// <summary>
    /// Navigation property to the <seealso cref="Entities.Cart"/> entity.
    /// </summary>
    public Cart Cart { get; set; }
}
