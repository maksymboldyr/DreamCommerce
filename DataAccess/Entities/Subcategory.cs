using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

/// <summary>
/// Represents a subcategory of a <seealso cref="Entities.Category"/>. Inherits from <seealso cref="BaseEntity"/>.
/// </summary>
public class Subcategory : BaseEntity
{
    /// <summary>
    /// Gets or sets the name of the subcategory. Is required and has a maximum length of 100 characters.
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the subcategory.
    /// </summary>
    [Required]
    public string CategoryId { get; set; }

    /// <summary>
    /// Navigation property for the <seealso cref="Entities.Category"/> this subcategory belongs to.
    /// </summary>
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }

    /// <summary>
    /// Navigation property for the <seealso cref="Entities.Product"/>s that belong to this subcategory.
    /// </summary>
    public ICollection<Product> Products { get; set; }

    /// <summary>
    /// Navigation property for the <seealso cref="Entities.Tag"/> entities that belong to this subcategory.
    /// </summary>
    public ICollection<Tag> Tags { get; set; }
}
