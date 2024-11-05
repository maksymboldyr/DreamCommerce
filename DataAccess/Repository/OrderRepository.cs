using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository(ApplicationDbContext context) : RepositoryBase<Order>(context)
    {
        public async Task<Order> GetOrderWithDetailsByIdAsync(string id)
        {
            var order = await dbSet.Where(o => o.Id == id)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product).FirstOrDefaultAsync();

            return order ?? throw new KeyNotFoundException("Order not found");
        }
    }
}
