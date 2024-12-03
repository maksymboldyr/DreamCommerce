using BusinessLogic.DTO.Catalogue;

namespace BusinessLogic.Interfaces;

/// <summary>
/// Represents a product service. Defines methods for managing products
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Gets all products
    /// </summary>
    /// <returns> Collection of <see cref="ProductDto"/> objects</returns>
    Task<IEnumerable<ProductDto>> GetProducts();

    /// <summary>
    /// Gets products by given filter with pagination and sorting
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <param name="sortField"></param>
    /// <param name="sortOrder"></param>
    /// <returns> Filtered, ordered and paginated collection of <see cref="ProductDto"/> objects and total count of products.</returns>
    Task<(IEnumerable<ProductDto>, int)> GetProductsWithCount(string filter, int page, int pageSize, string sortField, string sortOrder);

    /// <summary>
    /// Gets product by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns> <see cref="ProductDto"/> object</returns>
    Task<ProductDto> GetProductById(string id);

    /// <summary>
    /// Creates new product
    /// </summary>
    /// <param name="productDto"></param>
    Task CreateProduct(ProductDto productDto);

    /// <summary>
    /// Updates product
    /// </summary>
    /// <param name="productDto"></param>
    /// <returns></returns>
    Task UpdateProduct(ProductDto productDto);

    /// <summary>
    /// Deletes product by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteProduct(string id);
}
