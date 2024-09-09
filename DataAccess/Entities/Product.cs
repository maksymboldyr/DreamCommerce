namespace DataAccess.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }
    }
}
