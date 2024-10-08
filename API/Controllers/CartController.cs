using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<CartDto>> GetCartAsync(string userId)
        {
            var cart = await _cartService.GetUserCartAsync(userId);
            return Ok(cart);
        }

        [HttpPost("add")]
        public async Task<ActionResult<CartDto>> AddItemToCartAsync([FromBody] EditProductInCartDto productInCartDto)
        {
            await _cartService.AddProductToCartAsync(productInCartDto);
            return Ok();
        }

        [HttpPost("remove")]
        public async Task<ActionResult<CartDto>> RemoveItemFromCartAsync([FromBody] EditProductInCartDto productInCartDto)
        {
            await _cartService.RemoveProductFromCartAsync(productInCartDto);
            return Ok();
        }

        [HttpPost("removeAll")]
        public async Task<ActionResult<CartDto>> RemoveAllItemsFromCartAsync([FromBody] EditProductInCartDto productInCartDto)
        {
            await _cartService.RemoveItemFromCartAsync(productInCartDto);
            return Ok();
        }

        [HttpDelete("clear/{userId}")]
        public async Task<ActionResult<CartDto>> ClearCartAsync(string userId)
        {
            await _cartService.ClearCartAsync(userId);
            return Ok();
        }
    }
}
