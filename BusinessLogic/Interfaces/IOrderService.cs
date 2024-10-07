using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(OrderDTO orderModel);
        Task CreateOrderDetail(OrderDetailDTO orderDetailModel);
        Task DeleteOrder(string id);
        Task DeleteOrderDetail(string id);
        Task<OrderDTO> GetOrderById(string id);
        Task<OrderDTO> GetOrderByIdWithDetails(string id);
        Task<OrderDetailDTO> GetOrderDetailById(string id);
        Task<IEnumerable<OrderDetailDTO>> GetOrderDetails(int page, int pageSize);
        Task<IEnumerable<OrderDTO>> GetOrders(string filter, int page, int pageSize, string sortField, string sortOrder = "asc");
        Task<IEnumerable<OrderDTO>> GetOrdersByUserId(string userId, int page, int pageSize);
        void UpdateOrder(OrderDTO orderModel);
        void UpdateOrderDetail(OrderDetailDTO orderDetailModel);
    }
}
