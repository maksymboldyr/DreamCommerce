using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Repository;

namespace BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateProduct(ProductDTO productModel)
        {
            var product = new Product
            {
                Name = productModel.Name,
                Description = productModel.Description,
                CategoryId = productModel.CategoryId,
                SubcategoryId = productModel.SubcategoryId,
                Price = productModel.Price,
                Stock = productModel.Stock,
                Discount = productModel.Discount,
                ImageUrl = productModel.ImageUrl
            };

            await _unitOfWork.ProductRepository.InsertAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteProduct(string id)
        {
            await _unitOfWork.ProductRepository.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ProductDTO> GetProductById(string id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                SubcategoryId = product.SubcategoryId,
                Price = product.Price,
                Stock = product.Stock,
                Discount = product.Discount,
                ImageUrl = product.ImageUrl
            };
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = await _unitOfWork.ProductRepository.GetAsync();

            return products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CategoryId = p.CategoryId,
                SubcategoryId = p.SubcategoryId,
                Price = p.Price,
                Stock = p.Stock,
                Discount = p.Discount,
                ImageUrl = p.ImageUrl
            });
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts(string name, int page, int pageSize)
        {
            var filteredProducts = await _unitOfWork.ProductRepository.GetAsync(
                filter: p => p.Name.Contains(name),
                orderBy: q => q.OrderBy(p => p.Name),
                includeProperties: "Category,Subcategory");

            return filteredProducts.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CategoryId = p.CategoryId,
                SubcategoryId = p.SubcategoryId,
                Price = p.Price,
                Stock = p.Stock,
                Discount = p.Discount,
                ImageUrl = p.ImageUrl
            }).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public async Task UpdateProduct(ProductDTO productModel)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(productModel.Id);

            product.Name = productModel.Name;
            product.Description = productModel.Description;
            product.CategoryId = productModel.CategoryId;
            product.SubcategoryId = productModel.SubcategoryId;
            product.Price = productModel.Price;
            product.Stock = productModel.Stock;
            product.Discount = productModel.Discount;
            product.ImageUrl = productModel.ImageUrl;

            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.SaveAsync();
        }
    }
}
