using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Repository;

namespace BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly UnitOfWork _unitOfWork;

        public OrderService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task CreateOrder(OrderDTO orderModel)
        {
            var order = new Order
            {
                UserId = orderModel.UserId,
                Date = orderModel.OrderDate,
                Status = OrderStatus.New,
            };

            if (orderModel.OrderDetails != null)
            {
                foreach (var orderDetail in orderModel.OrderDetails)
                {
                    order.OrderDetails.Add(new OrderDetail
                    {
                        OrderId = order.Id,
                        ProductId = orderDetail.ProductId,
                        Quantity = orderDetail.Quantity,
                        TotalPrice = CalculateDetailTotalPrice(orderDetail),
                    });
                }
            }

            order.TotalPrice = order.OrderDetails.Sum(x => x.TotalPrice);
            
            await _unitOfWork.OrderRepository.InsertAsync(order);
            await _unitOfWork.SaveAsync();
        }

        public async Task CreateOrderDetail(OrderDetailDTO orderDetailModel)
        {
            var orderDetail = new OrderDetail
            {
                OrderId = orderDetailModel.OrderId,
                ProductId = orderDetailModel.ProductId,
                Quantity = orderDetailModel.Quantity,
                TotalPrice = CalculateDetailTotalPrice(orderDetailModel),
            };

            await _unitOfWork.OrderDetailRepository.InsertAsync(orderDetail);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteOrder(string id)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
            foreach (var orderDetail in order.OrderDetails)
            {
                await _unitOfWork.OrderDetailRepository.Delete(orderDetail.Id);
            }
            await _unitOfWork.OrderRepository.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteOrderDetail(string id)
        {
            await _unitOfWork.OrderDetailRepository.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<OrderDTO> GetOrderById(string id)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
            var orderModel = new OrderDTO
            {
                Id = order.Id,
                UserId = order.UserId,
                OrderDate = order.Date,
                Status = order.Status.ToString(),
                TotalPrice = order.TotalPrice,
            };

            return orderModel;
        }

        public async Task<OrderDTO> GetOrderByIdWithDetails(string id)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
            var orderDetails = await _unitOfWork.OrderDetailRepository.GetAsync(filter: od => od.OrderId == id);
            var orderModel = new OrderDTO
            {
                Id = order.Id,
                UserId = order.UserId,
                OrderDate = order.Date,
                Status = order.Status.ToString(),
                TotalPrice = order.TotalPrice,
                OrderDetails = orderDetails.Select(od => new OrderDetailDTO
                {
                    Id = od.Id,
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    Quantity = od.Quantity,
                    TotalPrice = od.TotalPrice,
                }).ToList(),
            };

            return orderModel;
        }

        public async Task<OrderDetailDTO> GetOrderDetailById(string id)
        {
            var orderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(id);

            var orderDetailModel = new OrderDetailDTO
            {
                Id = orderDetail.Id,
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
                Quantity = orderDetail.Quantity,
                TotalPrice = orderDetail.TotalPrice,
            };

            return orderDetailModel;
        }

        public async Task<IEnumerable<OrderDetailDTO>> GetOrderDetails()
        {
            var orderDetails = await _unitOfWork.OrderDetailRepository.GetAsync();
            return orderDetails.Select(od => new OrderDetailDTO
            {
                Id = od.Id,
                OrderId = od.OrderId,
                ProductId = od.ProductId,
                Quantity = od.Quantity,
                TotalPrice = od.TotalPrice,
            });
        }

        public async Task<IEnumerable<OrderDetailDTO>> GetOrderDetails(int page, int pageSize)
        {
            var orderDetails = await _unitOfWork.OrderDetailRepository.GetAsync();
            var orderDetailsModels = orderDetails.Select(od => new OrderDetailDTO
            {
                Id = od.Id,
                OrderId = od.OrderId,
                ProductId = od.ProductId,
                Quantity = od.Quantity,
                TotalPrice = od.TotalPrice,
            });

            return orderDetailsModels.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrders()
        {
            var orders = await _unitOfWork.OrderRepository.GetAsync();
            return orders.Select(o => new OrderDTO
            {
                Id = o.Id,
                UserId = o.UserId,
                OrderDate = o.Date,
                Status = o.Status.ToString(),
                TotalPrice = o.TotalPrice,
            });
        }

        public async Task<IEnumerable<OrderDTO>> GetOrders(int page, int pageSize)
        {
            var orders = await _unitOfWork.OrderRepository.GetAsync();
            return orders.Select(o => new OrderDTO
            {
                Id = o.Id,
                UserId = o.UserId,
                OrderDate = o.Date,
                Status = o.Status.ToString(),
                TotalPrice = o.TotalPrice,
            }).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersByUserId(string userId, int page, int pageSize)
        {
            var orders = await _unitOfWork.OrderRepository.GetAsync(filter: o => o.UserId == userId, orderBy: o => o.OrderByDescending(x => x.Date));
            return orders.Select(o => new OrderDTO
            {
                Id = o.Id,
                UserId = o.UserId,
                OrderDate = o.Date,
                Status = o.Status.ToString(),
                TotalPrice = o.TotalPrice,
            }).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersByUserIdWithDetails(string userId, int page, int pageSize)
        {
            var orders = await _unitOfWork.OrderRepository.GetAsync(
                filter: o => o.UserId == userId, 
                orderBy: o => o.OrderByDescending(x => x.Date),
                includeProperties:"OrderDetails");

            return orders.Select(o => new OrderDTO
            {
                Id = o.Id,
                UserId = o.UserId,
                OrderDate = o.Date,
                Status = o.Status.ToString(),
                TotalPrice = o.TotalPrice,
                OrderDetails = o.OrderDetails.Select(od => new OrderDetailDTO
                {
                    Id = od.Id,
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    Quantity = od.Quantity,
                    TotalPrice = od.TotalPrice,
                }).ToList(),
            }).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersWithDetails(int page, int pageSize)
        {
            var orders = await _unitOfWork.OrderRepository.GetAsync(includeProperties: "OrderDetails");

            return orders.Select(o => new OrderDTO
            {
                Id = o.Id,
                UserId = o.UserId,
                OrderDate = o.Date,
                Status = o.Status.ToString(),
                TotalPrice = o.TotalPrice,
                OrderDetails = o.OrderDetails.Select(od => new OrderDetailDTO
                {
                    Id = od.Id,
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    Quantity = od.Quantity,
                    TotalPrice = od.TotalPrice,
                }).ToList(),
            }).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public async Task UpdateOrder(OrderDTO orderModel)
        {
            var order = new Order
            {
                Id = orderModel.Id,
                UserId = orderModel.UserId,
                Date = orderModel.OrderDate,
                Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), orderModel.Status),
                OrderDetails = orderModel.OrderDetails.Select(od => new OrderDetail
                {
                    Id = od.Id,
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    Quantity = od.Quantity,
                    TotalPrice = CalculateDetailTotalPrice(od),
                }).ToList(),
            };

            order.TotalPrice = order.OrderDetails.Sum(x => x.TotalPrice);
            
            _unitOfWork.OrderRepository.Update(order);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateOrderDetail(OrderDetailDTO orderDetailModel)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(orderDetailModel.ProductId);
            var orderDetail = new OrderDetail
            {
                Id = orderDetailModel.Id,
                OrderId = orderDetailModel.OrderId,
                ProductId = orderDetailModel.ProductId,
                Quantity = orderDetailModel.Quantity,
                TotalPrice = CalculateDetailTotalPrice(orderDetailModel),
            };            

            _unitOfWork.OrderDetailRepository.Update(orderDetail);
            await _unitOfWork.SaveAsync();
        }

        private decimal CalculateDetailTotalPrice(OrderDetailDTO orderDetailModel)
        {
            var product = _unitOfWork.ProductRepository.GetByIdAsync(orderDetailModel.ProductId).Result;
            return (product.Price - (decimal)Math.Ceiling((float)product.Price * product.Discount)) * orderDetailModel.Quantity;
        }
    }
}
