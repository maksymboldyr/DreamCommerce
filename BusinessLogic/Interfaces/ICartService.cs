using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces;

/// <summary>
/// Interface for cart service. Defines methods for managing user cart.
/// </summary>
public interface ICartService
{
    /// <summary>
    /// Adds product to cart.
    /// </summary>
    /// <param name="productInCartDto"></param>
    Task AddProductToCartAsync(EditProductInCartDto productInCartDto);

    /// <summary>
    /// Clears user cart.
    /// </summary>
    /// <param name="userId"></param>
    Task ClearCartAsync(string userId);

    /// <summary>
    /// Gets user cart.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns> <see cref="CartDto"/> object.</returns>
    Task<CartDto> GetUserCartAsync(string userId);

    /// <summary>
    /// Removes item from cart.
    /// </summary>
    /// <param name="productInCartDto"></param>
    Task RemoveItemFromCartAsync(EditProductInCartDto productInCartDto);

    /// <summary>
    /// Removes product from cart.
    /// </summary>
    /// <param name="productInCartDto"></param>
    /// <returns></returns>
    Task RemoveProductFromCartAsync(EditProductInCartDto productInCartDto);
}