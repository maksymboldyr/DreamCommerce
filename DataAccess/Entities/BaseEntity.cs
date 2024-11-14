using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

/// <summary>
/// Base class for all entities classes except for the Identity classes. Ensures that all entities have an Id, CreatedAt and UpdatedAt properties.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Represents the GUID primary key of the entity in the database.
    /// </summary>
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }

    /// <summary>
    /// Represents the date and time when the entity was created in the database.
    /// </summary>
    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Represents the date and time when the entity was last updated in the database.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Marks the entity as updated by setting the UpdatedAt property to the current date and time.
    /// </summary>
    public void MarkAsUpdated()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}
