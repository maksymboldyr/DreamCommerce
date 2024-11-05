using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

/// <summary>
/// Represents the join entity between <seealso cref="Entities.Product"/> and <seealso cref="Entities.Tag"/> entities.
/// </summary>
public class ProductTag
{
    /// <summary>
    /// Foreign key to <seealso cref="Product"/> entity.
    /// </summary>
    [ForeignKey("Product")]
    public string ProductId { get; set; }

    /// <summary>
    /// Navigation property to <seealso cref="Entities.Product"/> entity.
    /// </summary>
    public Product Product { get; set; }

    /// <summary>
    /// Foreign key to <seealso cref="Tag"/> entity.
    /// </summary>
    [ForeignKey("Tag")]
    public string TagId { get; set; }

    /// <summary>
    /// Navigation property to <seealso cref="Entities.Tag"/> entity.
    /// </summary>
    public Tag Tag { get; set; }

    /// <summary>
    /// Foreign key to <seealso cref="TagValue"/> entity.
    /// </summary>
    [ForeignKey("TagValue")]
    public string TagValueId { get; set; }

    /// <summary>
    /// Navigation property to <seealso cref="Entities.TagValue"/> entity.
    /// </summary>
    public TagValue TagValue { get; set; }
}
