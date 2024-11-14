using BusinessLogic.DTO.Catalogue;

namespace BusinessLogic.DTO
{
    public class CartItemDto
    {
        public ProductDto ProductDTO { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
