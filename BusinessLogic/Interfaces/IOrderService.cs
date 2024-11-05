using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        Task PlaceOrderAsync(OrderDTO orderDTO);
        Task ChangeStatus(string orderId, string status);
        Task DeleteOrder(string orderId);
        Task<OrderDTO> GetOrderWithDetailsById(string orderId);
        Task<(IEnumerable<OrderDTO>, int)> GetOrdersWithCount(string filter, int page, int pageSize, string sortField, string sortOrder);
        Task<IEnumerable<OrderDTO>> GetOrdersByUserId(string userId);
    }
}
