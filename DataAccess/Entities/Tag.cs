using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public class Tag : BaseEntity
{
    [Required]
    public string SubcategoryId { get; set; }

    [ForeignKey("SubcategoryId")]
    public Subcategory Subcategory { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public ICollection<TagValue> TagValues { get; set; }
    public ICollection<ProductTag> ProductTags { get; set; }
}
