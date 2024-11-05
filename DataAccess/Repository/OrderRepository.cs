using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository;

/// <summary>
/// Repository for the <seealso cref="Order"/> entity. Inherits from <seealso cref="RepositoryBase{T}"/>.
/// </summary>
/// <param name="context"></param>
public class OrderRepository(ApplicationDbContext context) : RepositoryBase<Order>(context)
{
    /// <summary>
    /// Gets an order entity by its ID with its details.
    /// </summary>
    /// <param name="id"></param>
    /// <returns><seealso cref="Order"/> entity.</returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<Order> GetOrderWithDetailsByIdAsync(string id)
    {
        var order = await dbSet.Where(o => o.Id == id)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product).FirstOrDefaultAsync();

        return order ?? throw new KeyNotFoundException("Order not found");
    }
}
