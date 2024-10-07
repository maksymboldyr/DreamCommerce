using DataAccess.Entities.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public enum OrderStatus
    {
        New,
        Confirmed,
        Shipped,
        Delivered,
        Canceled,
        Completed
    }

    public class Order : BaseEntity
    {
        [Required] // UserId is required
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required] // Date is required
        public DateTime Date { get; set; }

        [Required] // Status is required
        public OrderStatus Status { get; set; }

        [Required] // TotalPrice is required
        [Column(TypeName = "decimal(18,2)")] // Specify decimal precision
        public decimal TotalPrice { get; set; }

        public User User { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
