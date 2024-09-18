using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Subcategory : BaseEntity
    {
        public string Name { get; set; }
        [ForeignKey("Category")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Product> Products { get; set; }
    }
}
