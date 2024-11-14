using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

/// <summary>
/// Represents a category of the product. Inherits from <see cref="BaseEntity"/>. Category can have multiple <seealso cref="Subcategory"/> entities.
/// </summary>
public class Category : BaseEntity
{
    /// <summary>
    /// Gets or sets the name of the category.
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    /// <summary>
    /// Navigation property for the subcategories this category contains.
    /// </summary>
    public ICollection<Subcategory> Subcategories { get; set; }
}
