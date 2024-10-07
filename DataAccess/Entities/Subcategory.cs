using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public class Subcategory : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public string CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category Category { get; set; }

    public ICollection<Product> Products { get; set; }
    public ICollection<Tag> Tags { get; set; }
}
