namespace BusinessLogic.DTO
{
    public class OrderDTO
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? AddressId { get; set; }
        public DateTime CreatedAt { get; set; }
        public AddressDto? Address { get; set; }
        public List<OrderDetailDTO>? OrderDetails { get; set; } = new List<OrderDetailDTO>();
        public string? Status { get; set; }

    }
}
