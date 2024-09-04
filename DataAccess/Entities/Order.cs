using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
