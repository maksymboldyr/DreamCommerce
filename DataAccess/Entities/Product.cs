using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public int Stock { get; set; }
        [ForeignKey("Category")]
        public string? CategoryId { get; set; }
        [ForeignKey("Subcategory")]
        public string? SubcategoryId { get; set; }
        public string? ImageUrl { get; set; }
        public Subcategory Subcategory { get; set; }
        public Category Category { get; set; }
    }
}
