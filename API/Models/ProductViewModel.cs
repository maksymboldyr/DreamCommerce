namespace API.Models
{
    public class ProductViewModel
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string SubcategoryId { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public float Discount { get; set; }
        public IFormFile Image { get; set; }
    }
}
