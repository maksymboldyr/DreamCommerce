using DataAccess.Entities.Users;

namespace DataAccess.Entities
{
    public class Order : BaseEntity
    {
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
