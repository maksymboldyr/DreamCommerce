using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

/// <summary>
/// Represents the value of a <seealso cref="Entities.Tag"/> entity.
/// </summary>
public class TagValue : BaseEntity
{
    /// <summary>
    /// Foreign key to <seealso cref="Tag"/> entity. Is required.
    /// </summary>
    [Required]
    public string TagId { get; set; }

    /// <summary>
    /// Navigation property to <seealso cref="Entities.Tag"/> entity.
    /// </summary>
    [ForeignKey("TagId")]
    public Tag Tag { get; set; }

    /// <summary>
    /// Value of the tag. Is required and has a maximum length of 100 characters.
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Value { get; set; }

    /// <summary>
    /// Navigation property to join entity between <seealso cref="Product"/> and <seealso cref="TagValue"/> entities.
    /// </summary>
    public ICollection<ProductTag> ProductTags { get; set; }
}
