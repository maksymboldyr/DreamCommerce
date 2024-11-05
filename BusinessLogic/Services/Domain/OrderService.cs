using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Repository;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Domain
{
    public class OrderService : IOrderService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly OrderRepository orderRepository;
        private readonly FilterBuilderService filterBuilderService;
        private readonly SortingService<Order> orderSortingService;

        public OrderService(UnitOfWork unitOfWork, FilterBuilderService filterBuilderService, SortingService<Order> orderSortingService)
        {
            this.unitOfWork = unitOfWork;
            orderRepository = unitOfWork.OrderRepository as OrderRepository;

            if (orderRepository == null)
            {
                throw new ArgumentException("OrderRepository is not of type OrderRepository");
            }

            this.filterBuilderService = filterBuilderService;
            this.orderSortingService = orderSortingService;
        }

        public async Task ChangeStatus(string orderId, string status)
        {
            var order = await unitOfWork.OrderRepository.GetByIdAsync(orderId);
            order.Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), status);
            unitOfWork.OrderRepository.Update(order);
        }

        public async Task DeleteOrder(string orderId)
        {
            var order = await unitOfWork.OrderRepository.GetByIdAsync(orderId);
            var orderDetails = await unitOfWork.OrderDetailRepository.GetAsync(filter: od => od.OrderId == orderId);

            foreach (var orderDetail in orderDetails)
            {
                await unitOfWork.OrderDetailRepository.DeleteAsync(orderDetail.Id);
            }

            await unitOfWork.OrderRepository.DeleteAsync(orderId);
        }

        public async Task<(IEnumerable<OrderDTO>, int)> GetOrdersWithCount(string filter, int page, int pageSize, string sortField, string sortOrder)
        {
            var filterExpression = filterBuilderService.BuildFilter<Order>(filter);
            var orders = await unitOfWork.OrderRepository.GetAsync(
                filter: filterExpression,
                orderBy: orderSortingService.GetSortExpression(sortField, sortOrder),
                includeProperties: "Address"
            );
            var ordersDTO = orders.Select(o => o.Adapt<OrderDTO>()).ToList();
            var count = orders.Count();

            var pagedOrders = ordersDTO.Skip((page - 1) * pageSize).Take(pageSize);

            return (pagedOrders, count);
        }

        public async Task<OrderDTO> GetOrderWithDetailsById(string orderId)
        {
            var order = await orderRepository.GetOrderWithDetailsByIdAsync(orderId);
            return order.Adapt<OrderDTO>();
        }

        public async Task PlaceOrderAsync(OrderDTO orderDTO)
        {
            if (orderDTO == null)
            {
                throw new ArgumentNullException(nameof(orderDTO));
            }

            if (orderDTO.OrderDetails == null || orderDTO.OrderDetails.Count == 0)
            {
                throw new ArgumentException("Order must have at least one order detail");
            }

            var order = orderDTO.Adapt<Order>();

            if (order.AddressId == null)
            {
                var address = new Address
                {
                    Apartment = order.Address.Apartment,
                    Building = order.Address.Building,
                    Street = order.Address.Street,
                    City = order.Address.City,
                    Country = order.Address.Country,
                    ZipCode = order.Address.ZipCode
                };

                order.AddressId = await unitOfWork.AddressRepository.InsertAsync(address);
            }

            order.TotalPrice = await CheckTotalPrice(orderDTO);

            await orderRepository.InsertAsync(order);
        }

        public async Task<decimal> CheckTotalPrice(OrderDTO orderDTO)
        {
            if (orderDTO.OrderDetails == null || orderDTO.OrderDetails.Count == 0)
            {
                throw new ArgumentException("Order must have at least one order detail");
            }

            var products = await unitOfWork.ProductRepository.GetAsync(filter: p => orderDTO.OrderDetails.Select(od => od.ProductId).Contains(p.Id));
            var totalPrice = 0m;
            totalPrice = orderDTO.OrderDetails.Sum(od => products.First(p => p.Id == od.ProductId).Price * od.Quantity);
            return totalPrice;
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersByUserId(string userId)
        {
            var orders = await unitOfWork.OrderRepository.GetAsync(
                    filter: o => o.UserId == userId,
                    includeProperties: "Address"
                    );
            return orders.Select(o => o.Adapt<OrderDTO>()).ToList();
        }
    }
}
