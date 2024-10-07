using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Repository;
using Mapster;
using System.Linq.Expressions;

namespace BusinessLogic.Services.Domain
{
    public class OrderService(
            UnitOfWork unitOfWork,
            FilterBuilderService filterBuilderService,
            SortingService<Order> sortingService) : IOrderService
    {
        public async Task CreateOrder(OrderDTO orderModel)
        {
            var order = orderModel.Adapt<Order>();
            order.Status = OrderStatus.New;

            if (orderModel.OrderDetails != null)
            {
                foreach (var orderDetailModel in orderModel.OrderDetails)
                {
                    var orderDetail = orderDetailModel.Adapt<OrderDetail>();
                    order.OrderDetails.Add(orderDetail);
                }
                order.TotalPrice = order.OrderDetails.Sum(od => CalculateDetailTotalPrice(od.Adapt<OrderDetailDTO>()));
            }

            await unitOfWork.OrderRepository.InsertAsync(order);
        }

        public async Task CreateOrderDetail(OrderDetailDTO orderDetailModel)
        {
            var orderDetail = orderDetailModel.Adapt<OrderDetail>();
            orderDetail.TotalPrice = CalculateDetailTotalPrice(orderDetailModel);

            await unitOfWork.OrderDetailRepository.InsertAsync(orderDetail);
        }

        public async Task DeleteOrder(string id)
        {
            await unitOfWork.OrderRepository.DeleteAsync(id);
        }

        public async Task DeleteOrderDetail(string id)
        {
            await unitOfWork.OrderDetailRepository.DeleteAsync(id);
        }

        public async Task<OrderDTO> GetOrderById(string id)
        {
            var order = await unitOfWork.OrderRepository.GetByIdAsync(id);
            return order.Adapt<OrderDTO>();
        }

        public async Task<OrderDTO> GetOrderByIdWithDetails(string id)
        {
            var order = await unitOfWork.OrderRepository.GetAsync(o => o.Id == id, includeProperties: "OrderDetails");

            return order.FirstOrDefault().Adapt<OrderDTO>();
        }

        public async Task<OrderDetailDTO> GetOrderDetailById(string id)
        {
            var orderDetail = await unitOfWork.OrderDetailRepository.GetByIdAsync(id);
            return orderDetail.Adapt<OrderDetailDTO>();
        }

        public async Task<IEnumerable<OrderDetailDTO>> GetOrderDetails(int page, int pageSize)
        {
            var orderDetails = await unitOfWork.OrderDetailRepository.GetAsync();
            return orderDetails
                .Select(od => od.Adapt<OrderDetailDTO>())
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrders(string filter, int page, int pageSize, string sortField, string sortOrder = "asc")
        {
            Expression<Func<Order, bool>>? filterExpression = filterBuilderService.BuildFilter<Order>(filter);
            Func<IQueryable<Order>, IOrderedQueryable<Order>>? sortingExpression = sortingService.GetSortExpression(sortField, sortOrder);

            var orders = await unitOfWork.OrderRepository.GetAsync(filter: filterExpression, orderBy: sortingExpression);

            return orders
                .Select(o => o.Adapt<OrderDTO>())
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersByUserId(string userId, int page, int pageSize)
        {
            var orders = await unitOfWork.OrderRepository.GetAsync(o => o.UserId == userId);
            return orders
                .Select(o => o.Adapt<OrderDTO>())
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public void UpdateOrder(OrderDTO orderModel)
        {
            var order = orderModel.Adapt<Order>();
            order.TotalPrice = orderModel.OrderDetails?.Sum(od => CalculateDetailTotalPrice(od)) ?? 0;

            unitOfWork.OrderRepository.Update(order);
        }

        public void UpdateOrderDetail(OrderDetailDTO orderDetailModel)
        {
            var orderDetail = orderDetailModel.Adapt<OrderDetail>();
            orderDetail.TotalPrice = CalculateDetailTotalPrice(orderDetailModel);

            unitOfWork.OrderDetailRepository.Update(orderDetail);
        }

        private decimal CalculateDetailTotalPrice(OrderDetailDTO orderDetailModel)
        {
            var product = unitOfWork.ProductRepository.GetByIdAsync(orderDetailModel.ProductId).Result;
            return (product.Price - (decimal)Math.Ceiling((float)product.Price * product.Discount)) * orderDetailModel.Quantity;
        }
    }
}
