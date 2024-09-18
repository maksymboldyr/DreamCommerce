using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces
{
    public interface IProductService 
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<IEnumerable<ProductDTO>> GetProducts(string name, int page, int pageSize);
        Task<ProductDTO> GetProductById(string id);
        Task CreateProduct(ProductDTO productModel);
        Task UpdateProduct(ProductDTO productModel);
        Task DeleteProduct(string id);
    }
}
