namespace BusinessLogic.DTO
{
    public class CartDto
    {
        public string UserId { get; set; }
        public List<CartItemDto> CartItems { get; set; } = new List<CartItemDto>();
        public decimal Total { get; set; }
    }
}
