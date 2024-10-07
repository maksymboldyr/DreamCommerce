using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class OrderDetail : BaseEntity
    {
        [Required] // OrderId is required
        [ForeignKey("Order")]
        public string OrderId { get; set; }

        public Order Order { get; set; }

        [Required] // ProductId is required
        [ForeignKey("Product")]
        public string ProductId { get; set; }
        public Product Product { get; set; }

        [Required] // Quantity is required
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        [Required] // TotalPrice is required
        [Column(TypeName = "decimal(18,2)")] // Specify decimal precision
        public decimal TotalPrice { get; set; }
    }
}
