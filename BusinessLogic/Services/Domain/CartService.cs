using BusinessLogic.DTO;
using DataAccess.Repository;
using Mapster;
using DataAccess.Entities;
using BusinessLogic.Interfaces;
using BusinessLogic.DTO.Catalogue;

namespace BusinessLogic.Services.Domain;

/// <summary>
/// Represents a cart service. Defines methods for managing carts.
/// </summary>
public class CartService : ICartService
{
    private readonly UnitOfWork unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="CartService"/> class.
    /// </summary>
    /// <param name="unitOfWork">The unit of work.</param>
    public CartService(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Gets the user's cart.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <returns> <see cref="CartDto"/> object.</returns>
    public async Task<CartDto> GetUserCartAsync(string userId)
    {
        var cartEnumerable = await unitOfWork.CartRepository.GetAsync(
            c => c.UserId == userId
        );
        var cart = cartEnumerable.FirstOrDefault();
        if (cart == null)
        {
            return null;
        }

        var cartDto = new CartDto
        {
            UserId = cart.UserId,
            CartItems = cart.CartItems.Select(ci => new CartItemDto
            {
                Quantity = ci.Quantity,
                ProductDTO = ci.Product.Adapt<ProductDto>(),
                Total = ci.Quantity * ci.Product.Price,
            }).ToList()
        };

        cartDto.Total = cartDto.CartItems.Sum(ci => ci.Total);

        return cartDto;
    }

    /// <summary>
    /// Adds a product to the cart.
    /// </summary>
    /// <param name="productInCartDto">The product in cart DTO.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task AddProductToCartAsync(EditProductInCartDto productInCartDto)
    {
        var existingCart = (await unitOfWork.CartRepository.GetAsync(c => c.UserId == productInCartDto.UserId)).FirstOrDefault();

        if (existingCart == null)
        {
            var cart = new Cart
            {
                UserId = productInCartDto.UserId,
                CartItems = new List<CartItem>
                {
                    new CartItem
                    {
                        ProductId = productInCartDto.ProductId,
                        Quantity = productInCartDto.Quantity,
                        CartId = productInCartDto.UserId
                    }
                }
            };
            await unitOfWork.CartRepository.InsertAsync(cart);
        }
        else
        {
            var existingCartItem = existingCart.CartItems.FirstOrDefault(ci => ci.ProductId == productInCartDto.ProductId);
            if (existingCartItem == null)
            {
                var cartItem = new CartItem
                {
                    ProductId = productInCartDto.ProductId,
                    Quantity = productInCartDto.Quantity,
                    CartId = existingCart.Id
                };
                await unitOfWork.CartItemRepository.InsertAsync(cartItem);
            }
            else
            {
                existingCartItem.Quantity += productInCartDto.Quantity;
                unitOfWork.CartItemRepository.Update(existingCartItem);
            }

            unitOfWork.CartRepository.Update(existingCart);
        }
    }

    /// <summary>
    /// Removes a product from the cart.
    /// </summary>
    /// <param name="productInCartDto">The product in cart DTO.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task RemoveProductFromCartAsync(EditProductInCartDto productInCartDto)
    {
        var existingCarts = await unitOfWork.CartRepository.GetAsync(c => c.UserId == productInCartDto.UserId);
        var existingCart = existingCarts.FirstOrDefault();

        if (existingCart == null)
        {
            return;
        }

        var existingCartItem = existingCart.CartItems.FirstOrDefault(ci => ci.ProductId == productInCartDto.ProductId);

        if (existingCartItem == null)
        {
            return;
        }

        if (existingCartItem.Quantity > productInCartDto.Quantity)
        {
            existingCartItem.Quantity -= productInCartDto.Quantity;
        }
        else
        {
            existingCart.CartItems.Remove(existingCartItem);
        }

        unitOfWork.CartRepository.Update(existingCart);
    }

    /// <summary>
    /// Clears the user's cart.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task ClearCartAsync(string userId)
    {
        var carts = await unitOfWork.CartRepository.GetAsync(c => c.UserId == userId);
        var cart = carts.FirstOrDefault();
        if (cart == null)
        {
            return;
        }

        foreach (var cartItem in cart.CartItems)
        {
            await unitOfWork.CartItemRepository.DeleteAsync(cartItem.Id);
        }

        cart.CartItems.Clear();

        unitOfWork.CartRepository.Update(cart);
    }

    /// <summary>
    /// Removes an item from the cart.
    /// </summary>
    /// <param name="productInCartDto">The product in cart DTO.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task RemoveItemFromCartAsync(EditProductInCartDto productInCartDto)
    {
        var existingCarts = await unitOfWork.CartRepository.GetAsync(c => c.UserId == productInCartDto.UserId);
        var existingCart = existingCarts.FirstOrDefault();

        if (existingCart == null)
        {
            return;
        }

        var existingCartItem = existingCart.CartItems.FirstOrDefault(ci => ci.ProductId == productInCartDto.ProductId);

        if (existingCartItem == null)
        {
            return;
        }

        await unitOfWork.CartItemRepository.DeleteAsync(existingCartItem.Id);
    }
}
