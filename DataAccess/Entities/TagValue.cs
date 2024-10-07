using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public class TagValue : BaseEntity
{
    [Required]
    public string TagId { get; set; }

    [ForeignKey("TagId")]
    public Tag Tag { get; set; }

    [Required]
    [MaxLength(100)]
    public string Value { get; set; }

    public ICollection<ProductTag> ProductTags { get; set; }
}
