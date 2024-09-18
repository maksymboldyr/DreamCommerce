namespace DataAccess.Entities
{
    public class Category : BaseEntity
    { 
        public string Name { get; set; }
        public List<Subcategory> Subcategories { get; } = new List<Subcategory>();
        public List<Product> Products { get; } = new List<Product>();
    }
}
