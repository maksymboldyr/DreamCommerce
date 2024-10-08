using BusinessLogic.DTO;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using DataAccess.Entities;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Services.Domain
{
    public class CartService(UnitOfWork unitOfWork) : ICartService
    {
        public async Task<CartDto> GetUserCartAsync(string userId)
        {
            var cartEnumerable = await unitOfWork.CartRepository.GetAsync(c => c.UserId == userId);
            var cart = cartEnumerable.FirstOrDefault();
            var cartItems = await unitOfWork.CartItemRepository.GetAsync(ci => ci.Cart.UserId == userId, includeProperties: "Product");
            if (cart == null)
            {
                return null;
            }

            cart.CartItems = cartItems.ToList();
            cart.UserId = userId;


            var cartDto = new CartDto
            {
                UserId = cart.UserId,
                CartItems = cart.CartItems.Select(ci => new CartItemDto
                {
                    Quantity = ci.Quantity,
                    ProductDTO = ci.Product.Adapt<ProductDTO>(),
                    Total = ci.Quantity * ci.Product.Price,
                }).ToList()
            };

            cartDto.Total = cartDto.CartItems.Sum(ci => ci.Total);

            return cartDto;
        }

        public async Task AddProductToCartAsync(EditProductInCartDto productInCartDto)
        {
            var existingCart = unitOfWork.CartRepository.GetAsync(c => c.UserId == productInCartDto.UserId, includeProperties: "CartItems").Result.FirstOrDefault();

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

        public async Task RemoveProductFromCartAsync(EditProductInCartDto productInCartDto)
        {

            var existingCarts = await unitOfWork.CartRepository.GetAsync(c => c.UserId == productInCartDto.UserId, includeProperties: "CartItems");
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

        public async Task ClearCartAsync(string userId)
        {
            var carts = await unitOfWork.CartRepository.GetAsync(c => c.UserId == userId, includeProperties: "CartItems");
            var cart = carts.FirstOrDefault();
            if (cart == null)
            {
                return;
            }

            cart.CartItems.Clear();
            unitOfWork.CartRepository.Update(cart);
        }

        public async Task RemoveItemFromCartAsync(EditProductInCartDto productInCartDto)
        {
            var existingCarts = await unitOfWork.CartRepository.GetAsync(c => c.UserId == productInCartDto.UserId, includeProperties: "CartItems");
            var existingCart = existingCarts.FirstOrDefault();

            if (existingCart == null) { 
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
}
