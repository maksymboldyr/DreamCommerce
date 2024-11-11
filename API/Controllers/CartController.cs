using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CartController(ICartService cartService) : ControllerBase
{
    [HttpGet("{userId}")]
    public async Task<ActionResult<CartDto>> GetCartAsync(string userId)
    {
        var cart = await cartService.GetUserCartAsync(userId);
        return Ok(cart);
    }

    [HttpPost("add")]
    public async Task<ActionResult<CartDto>> AddItemToCartAsync([FromBody] EditProductInCartDto productInCartDto)
    {
        await cartService.AddProductToCartAsync(productInCartDto);
        return Ok();
    }

    [HttpPost("remove")]
    public async Task<ActionResult<CartDto>> RemoveItemFromCartAsync([FromBody] EditProductInCartDto productInCartDto)
    {
        await cartService.RemoveProductFromCartAsync(productInCartDto);
        return Ok();
    }

    [HttpPost("removeAll")]
    public async Task<ActionResult<CartDto>> RemoveAllItemsFromCartAsync([FromBody] EditProductInCartDto productInCartDto)
    {
        await cartService.RemoveItemFromCartAsync(productInCartDto);
        return Ok();
    }

    [HttpDelete("clear/{userId}")]
    public async Task<ActionResult<CartDto>> ClearCartAsync(string userId)
    {
        await cartService.ClearCartAsync(userId);
        return Ok();
    }
}
