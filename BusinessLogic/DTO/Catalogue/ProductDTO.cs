namespace BusinessLogic.DTO.Catalogue
{
    public class ProductDTO
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string SubcategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? SubcategoryName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public float Discount { get; set; }
        public string? ImageUrl { get; set; }
    }
}
