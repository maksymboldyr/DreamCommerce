using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces
{
    public interface ICartService
    {
        Task AddProductToCartAsync(EditProductInCartDto productInCartDto);
        Task ClearCartAsync(string userId);
        Task<CartDto> GetUserCartAsync(string userId);
        Task RemoveItemFromCartAsync(EditProductInCartDto productInCartDto);
        Task RemoveProductFromCartAsync(EditProductInCartDto productInCartDto);
    }
}