using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class OrderDetail : BaseEntity
    {
        [ForeignKey("Order")]
        public string OrderId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Product")]
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
