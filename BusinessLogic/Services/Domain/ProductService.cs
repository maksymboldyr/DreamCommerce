using BusinessLogic.DTO.Catalogue;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Repository;
using Mapster;

namespace BusinessLogic.Services.Domain;

/// <summary>
/// Service for managing products.
/// </summary>
public class ProductService(
    UnitOfWork unitOfWork, 
    FilterBuilderService filterBuilderService, 
    SortingService<Product> productSortingService) : IProductService
{
    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="productDto">The product data transfer object.</param>
    public async Task CreateProduct(ProductDto productDto)
    {
        var product = productDto.Adapt<Product>();
        await unitOfWork.ProductRepository.InsertAsync(product);
    }

    /// <summary>
    /// Deletes a product by its id.
    /// </summary>
    /// <param name="id">The product identifier.</param>
    public async Task DeleteProduct(string id)
    {
        await unitOfWork.ProductRepository.DeleteAsync(id);
    }

    /// <summary>
    /// Gets a product by its id.
    /// </summary>
    /// <param name="id">The product identifier.</param>
    /// <returns><see cref="ProductDto"/> object.</returns>
    public async Task<ProductDto> GetProductById(string id)
    {
        // Get product by id with subcategory. Joining manually.
        var product = await unitOfWork.ProductRepository.GetByIdAsync(id);
        var productDto = product.Adapt<ProductDto>();
        var subcategory = await unitOfWork.SubcategoryRepository.GetByIdAsync(product.SubcategoryId);
        productDto.SubcategoryName = subcategory.Name;
        return productDto;
    }

    /// <summary>
    /// Gets all products.
    /// </summary>
    /// <returns>Collection of <see cref="ProductDto"/> objects.</returns>
    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        var products = await unitOfWork.ProductRepository.GetAsync();
        return products.Adapt<IEnumerable<ProductDto>>();
    }

    /// <summary>
    /// Gets products by given filter with pagination and sorting.
    /// </summary>
    /// <param name="filter">The filter string.</param>
    /// <param name="page">The page number.</param>
    /// <param name="pageSize">The page size.</param>
    /// <param name="sortField">The field to sort by.</param>
    /// <param name="sortOrder">The sort order (asc/desc).</param>
    /// <returns>Filtered, ordered, and paginated collection of <see cref="ProductDto"/> objects and the total count of filtered products before pagination.</returns>
    public async Task<(IEnumerable<ProductDto>, int)> GetProductsWithCount(string filter, int page, int pageSize, string sortField, string sortOrder)
    {
        var filterExpression = filterBuilderService.BuildFilter<Product>(filter);
        var sortingExpression = productSortingService.GetSortExpression(sortField, sortOrder);

        var filteredProducts = await unitOfWork.ProductRepository.GetAsync(
            filter: filterExpression,
            orderBy: sortingExpression,
            includeProperties: "Subcategory");

        var result = filteredProducts
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Adapt<IEnumerable<ProductDto>>();

        return (result, filteredProducts.Count());
    }

    /// <summary>
    /// Updates a product.
    /// </summary>
    /// <param name="productDto">The product data transfer object.</param>
    /// <exception cref="ArgumentNullException">Thrown when the productModel is null or the Id property of the productDto is null or empty.</exception>
    public async Task UpdateProduct(ProductDto productDto)
    {
        ArgumentNullException.ThrowIfNull(productDto);

        if (string.IsNullOrEmpty(productDto.Id))
        {
            throw new ArgumentNullException(nameof(productDto), "The 'Id' property of the productModel cannot be null or empty.");
        }

        var product = await unitOfWork.ProductRepository.GetByIdAsync(productDto.Id);
        productDto.Adapt(product);
        unitOfWork.ProductRepository.Update(product);
        await Task.CompletedTask;
    }
}
