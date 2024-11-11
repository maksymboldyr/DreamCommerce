using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Repository;
using Mapster;

namespace BusinessLogic.Services.Domain;

/// <summary>
/// Service for managing orders.
/// </summary>
public class OrderService : IOrderService
{
    private readonly UnitOfWork unitOfWork;
    private readonly OrderRepository orderRepository;
    private readonly FilterBuilderService filterBuilderService;
    private readonly SortingService<Order> orderSortingService;

    public OrderService(UnitOfWork unitOfWork, FilterBuilderService filterBuilderService, SortingService<Order> orderSortingService)
    {
        this.unitOfWork = unitOfWork;
        orderRepository = (OrderRepository)unitOfWork.OrderRepository;

        if (orderRepository == null)
        {
            throw new ArgumentException("OrderRepository is not of type OrderRepository");
        }

        this.filterBuilderService = filterBuilderService;
        this.orderSortingService = orderSortingService;
    }

    /// <summary>
    /// Places an order for the current user.
    /// </summary>
    /// <param name="orderDto">The order data transfer object.</param>
    /// <exception cref="ArgumentNullException">Thrown when the orderDto is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the orderDto does not have any order details.</exception>
    public async Task PlaceOrderAsync(OrderDto orderDto)
    {
        if (orderDto == null)
        {
            throw new ArgumentNullException(nameof(orderDto));
        }

        if (orderDto.OrderDetails == null || orderDto.OrderDetails.Count == 0)
        {
            throw new ArgumentException("Order must have at least one order detail");
        }

        var order = orderDto.Adapt<Order>();

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

        order.TotalPrice = await CheckTotalPrice(orderDto);

        await orderRepository.InsertAsync(order);
    }

    /// <summary>
    /// Changes the status of the order.
    /// </summary>
    /// <param name="orderId">The order identifier.</param>
    /// <param name="status">The new status of the order.</param>
    /// <exception cref="ArgumentException">Thrown when the status is not a valid OrderStatus.</exception>
    public async Task ChangeStatus(string orderId, string status)
    {
        var order = await unitOfWork.OrderRepository.GetByIdAsync(orderId);
        order.Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), status);
        unitOfWork.OrderRepository.Update(order);
    }

    /// <summary>
    /// Deletes an order by its id.
    /// </summary>
    /// <param name="orderId">The order identifier.</param>
    /// <exception cref="KeyNotFoundException">Thrown when the order is not found.</exception>"
    public async Task DeleteOrder(string orderId)
    {
        var orderDetails = await unitOfWork.OrderDetailRepository.GetAsync(filter: od => od.OrderId == orderId);

        foreach (var orderDetail in orderDetails)
        {
            await unitOfWork.OrderDetailRepository.DeleteAsync(orderDetail.Id);
        }

        await unitOfWork.OrderRepository.DeleteAsync(orderId);
    }

    /// <summary>
    /// Gets an order by its id.
    /// </summary>
    /// <param name="orderId">The order identifier.</param>
    /// <returns><see cref="OrderDto"/> object.</returns>
    public async Task<OrderDto> GetOrderWithDetailsById(string orderId)
    {
        var order = await orderRepository.GetOrderWithDetailsByIdAsync(orderId);
        return order.Adapt<OrderDto>();
    }

    /// <summary>
    /// Gets orders with pagination and sorting by given filter and sort parameters.
    /// </summary>
    /// <param name="filter">The filter string.</param>
    /// <param name="page">The page number.</param>
    /// <param name="pageSize">The page size.</param>
    /// <param name="sortField">The field to sort by.</param>
    /// <param name="sortOrder">The sort order (asc/desc).</param>
    /// <returns>Filtered, ordered and paginated collection of <see cref="OrderDto"/> objects and total count of orders.</returns>
    public async Task<(IEnumerable<OrderDto>, int)> GetOrdersWithCount(string filter, int page, int pageSize, string sortField, string sortOrder)
    {
        var filterExpression = filterBuilderService.BuildFilter<Order>(filter);
        var orders = await unitOfWork.OrderRepository.GetAsync(
            filter: filterExpression,
            orderBy: orderSortingService.GetSortExpression(sortField, sortOrder),
            includeProperties: "Address"
        );
        var ordersDTO = orders.Select(o => o.Adapt<OrderDto>()).ToList();
        var count = orders.Count();

        var pagedOrders = ordersDTO.Skip((page - 1) * pageSize).Take(pageSize);

        return (pagedOrders, count);
    }

    /// <summary>
    /// Gets all orders for the specified user by user id.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <returns>Collection of <see cref="OrderDto"/> objects.</returns>
    public async Task<IEnumerable<OrderDto>> GetOrdersByUserId(string userId)
    {
        var orders = await unitOfWork.OrderRepository.GetAsync(
                filter: o => o.UserId == userId,
                includeProperties: "Address"
                );
        return orders.Select(o => o.Adapt<OrderDto>()).ToList();
    }

    /// <summary>
    /// Checks the total price of the order.
    /// </summary>
    /// <param name="orderDTO">The order data transfer object.</param>
    /// <returns>The total price of the order.</returns>
    /// <exception cref="ArgumentException">Thrown when the order does not have any order details.</exception>
    private async Task<decimal> CheckTotalPrice(OrderDto orderDTO)
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
}
