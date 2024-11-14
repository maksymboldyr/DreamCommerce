using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

/// <summary>
/// Represents a product. Contains information about a product, such as its name, price, stock, etc.
/// </summary>
public class Product : BaseEntity
{
    /// <summary>
    /// Foreign key to <seealso cref="Subcategory"/> entity.
    /// </summary>
    [Required]
    public string SubcategoryId { get; set; }

    /// <summary>
    /// Navigation property to <seealso cref="Entities.Subcategory"/> entity.
    /// </summary>
    [ForeignKey("SubcategoryId")]
    public Subcategory Subcategory { get; set; }

    /// <summary>
    /// Description of the product. Is required and has a maximum length of 500 characters.
    /// </summary>
    [Required]
    [MaxLength(500)]
    public string Description { get; set; }

    /// <summary>
    /// Discount percentage of the product. Must be between 0 and 100 inclusive.
    /// </summary>
    [Range(0, 100)]
    public double Discount { get; set; }

    /// <summary>
    /// URL to the image of the product. Is required and has a maximum length of 255 characters.
    /// </summary>
    [MaxLength(255)]
    public string ImageUrl { get; set; }

    /// <summary>
    /// Name of the product. Is required and has a maximum length of 100 characters.
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    /// <summary>
    /// Price of the product. Is required and has a precision of 18 and a scale of 2.
    /// </summary>
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    /// <summary>
    /// Stock of the product. Must be greater than or equal to 0.
    /// </summary>
    [Required]
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

    /// <summary>
    /// Navigation property to join entity between <seealso cref="Product"/> and <seealso cref="Tag"/> entities.
    /// </summary>
    public List<ProductTag> ProductsTags { get; set; } = new List<ProductTag>();
}
