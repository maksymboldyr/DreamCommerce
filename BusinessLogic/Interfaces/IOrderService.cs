using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetOrders();
        Task<IEnumerable<OrderDTO>> GetOrders(int page, int pageSize);
        Task<IEnumerable<OrderDTO>> GetOrdersWithDetails(int page, int pageSize);
        Task<IEnumerable<OrderDTO>> GetOrdersByUserId(string userId, int page, int pageSize);
        Task<IEnumerable<OrderDTO>> GetOrdersByUserIdWithDetails(string userId, int page, int pageSize);

        Task<OrderDTO> GetOrderById(string id);
        Task<OrderDTO> GetOrderByIdWithDetails(string id);
        Task CreateOrder(OrderDTO orderModel);
        Task UpdateOrder(OrderDTO orderModel);
        Task DeleteOrder(string id);

        Task<IEnumerable<OrderDetailDTO>> GetOrderDetails();
        Task<IEnumerable<OrderDetailDTO>> GetOrderDetails(int page, int pageSize);
        Task<OrderDetailDTO> GetOrderDetailById(string id);
        Task CreateOrderDetail(OrderDetailDTO orderDetailModel);
        Task UpdateOrderDetail(OrderDetailDTO orderDetailModel);
        Task DeleteOrderDetail(string id);

    }
}
