using DataAccess.Entities.Users;
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
        
        [ForeignKey("User")]
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        public User User { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
