using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class CartItemDto
    {
        public ProductDTO ProductDTO { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
