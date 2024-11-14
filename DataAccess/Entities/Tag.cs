using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

/// <summary>
/// <para>Represents a tag entity. Used to filter products in addition to categories and subcategories.</para>
/// <remarks>
/// For example, if tag <seealso cref="Name"/> is "color", then <seealso cref="TagValue.Value"/> could be "red", "blue", "green", etc.
/// </remarks>
/// </summary>
public class Tag : BaseEntity
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
    /// Name of the tag.
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    /// <summary>
    /// Navigation property to related <seealso cref="TagValue"/> entities.
    /// </summary>
    public ICollection<TagValue> TagValues { get; set; }

    /// <summary>
    /// Navigation property to join entity between <seealso cref="Product"/> and <seealso cref="Tag"/> entities.
    /// </summary>
    public ICollection<ProductTag> ProductTags { get; set; }
}
