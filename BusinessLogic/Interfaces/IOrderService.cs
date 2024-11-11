using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces;

/// <summary>
/// Represents an order service. Defines methods for managing orders
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Places an order for the current user
    /// </summary>
    /// <param name="orderDTO"></param>
    Task PlaceOrderAsync(OrderDto orderDTO);

    /// <summary>
    /// Changes the status of the order
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="status"></param>
    Task ChangeStatus(string orderId, string status);

    /// <summary>
    /// Deletes an order by its id
    /// </summary>
    /// <param name="orderId"></param>
    Task DeleteOrder(string orderId);

    /// <summary>
    /// Gets an order by its id
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns> <see cref="OrderDto"/> object</returns>
    Task<OrderDto> GetOrderWithDetailsById(string orderId);

    /// <summary>
    /// Gets orders with pagination and sorting by given filter and sort parameters
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <param name="sortField"></param>
    /// <param name="sortOrder"></param>
    /// <returns>Filtered, ordered and paginated collection of <see cref="OrderDto"/> objects and total count of orders.</returns>
    Task<(IEnumerable<OrderDto>, int)> GetOrdersWithCount(string filter, int page, int pageSize, string sortField, string sortOrder);

    /// <summary>
    /// Gets all orders for the specified user by user id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<IEnumerable<OrderDto>> GetOrdersByUserId(string userId);
}
