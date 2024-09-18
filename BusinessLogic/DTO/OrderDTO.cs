namespace BusinessLogic.DTO
{
    public class OrderDTO
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetailDTO>? OrderDetails { get; set; } = new List<OrderDetailDTO>();
        public string? Status { get; set; }

    }
}
