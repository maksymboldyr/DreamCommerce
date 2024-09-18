using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var orders = await _orderService.GetOrders(page, pageSize);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("details")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrdersWithDetails([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var orders = await _orderService.GetOrdersWithDetails(page, pageSize);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Orders/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrdersByUserId(string userId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var orders = await _orderService.GetOrdersByUserId(userId, page, pageSize);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Orders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrderById(string id)
        {
            try
            {
                var order = await _orderService.GetOrderById(id);

                if (order == null)
                {
                    return NotFound();
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("with_details/{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrderByIdWithDetails(string id)
        {
            try
            {
                var order = await _orderService.GetOrderByIdWithDetails(id);

                if (order == null)
                {
                    return NotFound();
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("OrderDetails")]
        public async Task<ActionResult<IEnumerable<OrderDetailDTO>>> GetOrderDetails([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var orderDetails = await _orderService.GetOrderDetails(page, pageSize);
                return Ok(orderDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] OrderDTO order)
        {
            try
            {
                await _orderService.CreateOrder(order);
                return StatusCode(201, "Order created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Orders/OrderDetails
        [HttpPost("OrderDetails")]
        public async Task<ActionResult> CreateOrderDetail([FromBody] OrderDetailDTO orderDetail)
        {
            try
            {
                await _orderService.CreateOrderDetail(orderDetail);
                return StatusCode(201, "Order detail created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Orders/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(string id, [FromBody] OrderDTO order)
        {
            try
            {
                await _orderService.UpdateOrder(order);
                return StatusCode(200, "Order updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Orders/OrderDetails/{id}
        [HttpPut("OrderDetails/{id}")]
        public async Task<ActionResult> UpdateOrderDetail(string id, [FromBody] OrderDetailDTO orderDetail)
        {
            try
            {
                await _orderService.UpdateOrderDetail(orderDetail);
                return StatusCode(200, "Order detail updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Orders/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(string id)
        {
            try
            {
                await _orderService.DeleteOrder(id);
                return StatusCode(200, "Order deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Orders/OrderDetails/{id}
        [HttpDelete("OrderDetails/{id}")]
        public async Task<ActionResult> DeleteOrderDetail(string id)
        {
            try
            {
                await _orderService.DeleteOrderDetail(id);
                return StatusCode(200, "Order detail deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
