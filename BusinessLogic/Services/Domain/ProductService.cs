using BusinessLogic.DTO.Catalogue;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Repository;
using Mapster;

namespace BusinessLogic.Services.Domain;

public class ProductService(
    UnitOfWork unitOfWork,
    FilterBuilderService filterBuilderService,
    SortingService<Product> productSortingService) : IProductService
{
    public async Task CreateProduct(ProductDTO productModel)
    {
        var product = productModel.Adapt<Product>();
        await unitOfWork.ProductRepository.InsertAsync(product);
    }

    public async Task DeleteProduct(string id)
    {
        await unitOfWork.ProductRepository.DeleteAsync(id);
    }

    public async Task<ProductDTO> GetProductById(string id)
    {
        //get product by id with subcategory. joining manually
        var product = await unitOfWork.ProductRepository.GetByIdAsync(id);
        var productDto = product.Adapt<ProductDTO>();
        var subcategory = await unitOfWork.SubcategoryRepository.GetByIdAsync(product.SubcategoryId);
        productDto.SubcategoryName = subcategory.Name;
        return productDto;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var products = await unitOfWork.ProductRepository.GetAsync();
        return products.Adapt<IEnumerable<ProductDTO>>();
    }

    public async Task<(IEnumerable<ProductDTO>, int)> GetProductsWithCount(string name, int page, int pageSize, string sortField, string sortOrder)
    {
        var filterExpression = filterBuilderService.BuildFilter<Product>(name);
        var sortingExpression = productSortingService.GetSortExpression(sortField, sortOrder);

        var filteredProducts = await unitOfWork.ProductRepository.GetAsync(
            filter: filterExpression,
            orderBy: sortingExpression,
            includeProperties: "Subcategory");

        var result = filteredProducts
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Adapt<IEnumerable<ProductDTO>>();

        return (result, filteredProducts.Count());
    }

    public async Task UpdateProduct(ProductDTO productModel)
    {
        ArgumentNullException.ThrowIfNull(productModel);

        if (string.IsNullOrEmpty(productModel.Id))
        {
            throw new ArgumentNullException(nameof(productModel), "The 'Id' property of the productModel cannot be null or empty.");
        }

        var product = await unitOfWork.ProductRepository.GetByIdAsync(productModel.Id);
        productModel.Adapt(product);
        unitOfWork.ProductRepository.Update(product);
        await Task.CompletedTask;
    }
}
