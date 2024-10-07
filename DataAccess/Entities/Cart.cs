using DataAccess.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Cart: BaseEntity
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
