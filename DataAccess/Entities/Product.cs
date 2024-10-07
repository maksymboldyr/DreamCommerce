using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public class Product : BaseEntity
{
    [Required]
    public string SubcategoryId { get; set; }

    [ForeignKey("SubcategoryId")]
    public Subcategory Subcategory { get; set; }

    [Required]
    [MaxLength(500)]
    public string Description { get; set; }

    [Range(0, 100)]
    public double Discount { get; set; }

    [MaxLength(255)]
    public string ImageUrl { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

    public List<ProductTag> ProductsTags { get; set; } = new List<ProductTag>();
}
