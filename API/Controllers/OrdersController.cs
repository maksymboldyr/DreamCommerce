using API.Models;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly ICartService cartService;

        public OrdersController(IOrderService orderService, ICartService cartService)
        {
            this.orderService = orderService;
            this.cartService = cartService;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<TableViewModel<OrderDTO>>> GetProductsWithCount([FromQuery] string filter = "", [FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string sortField = "Id", [FromQuery] string sortOrder = "asc")
        {
            try
            {
                var (orders, count) = await orderService.GetOrdersWithCount(filter, page, pageSize, sortField, sortOrder);
                var tableViewModel = new TableViewModel<OrderDTO>
                {
                    Data = orders,
                    TotalCount = count
                };
                return Ok(tableViewModel);
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
                var order = await orderService.GetOrderWithDetailsById(id);

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

        //GET: api/Orders/User/{userId}
        [HttpGet("User/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrdersByUserId(string userId)
        {
            try
            {
                var orders = await orderService.GetOrdersByUserId(userId);
                return Ok(orders);
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
                await orderService.PlaceOrderAsync(order);
                await cartService.ClearCartAsync(order.UserId);
                return StatusCode(201, "Order created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Orders/status/{id}
        [HttpPut("status")]
        public async Task<ActionResult> ChangeOrderStatus([FromBody] OrderStatusDto orderStatusDto)
        {
            try
            {
                await orderService.ChangeStatus(orderStatusDto.Id, orderStatusDto.Name);
                return StatusCode(200, "Order status updated successfully");
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
                await orderService.DeleteOrder(id);
                return StatusCode(200, "Order deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
