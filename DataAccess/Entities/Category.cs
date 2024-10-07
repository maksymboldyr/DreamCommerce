using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class Category : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public ICollection<Subcategory> Subcategories { get; set; }
}
