using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Repository;

namespace BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly UnitOfWork _unitOfWork;

        public CategoryService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCategory(string name)
        {
            var category = new Category
            {
                Name = name
            };

            await _unitOfWork.CategoryRepository.InsertAsync(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task CreateSubcategory(SubcategoryDTO subcategoryModel)
        {
            var subcategory = new Subcategory
            {
                Name = subcategoryModel.Name,
                CategoryId = subcategoryModel.CategoryId
            };

            await _unitOfWork.SubcategoryRepository.InsertAsync(subcategory);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCategory(string id)
        {
            var subcategories = await _unitOfWork.SubcategoryRepository.GetAsync(filter: s => s.CategoryId == id);
            foreach (var subcategory in subcategories)
            {
                await _unitOfWork.SubcategoryRepository.Delete(subcategory.Id);
            }
            await _unitOfWork.CategoryRepository.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteSubcategory(string id)
        {
            await _unitOfWork.SubcategoryRepository.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAsync();

            return categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories(string name, int page, int pageSize)
        {
            var filteredCategories = await _unitOfWork.CategoryRepository.GetAsync(
                filter: c => c.Name.ToLower().Contains(name.ToLower()),
                orderBy: q => q.OrderBy(c => c.Name),
                includeProperties: "Subcategories");

            return filteredCategories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Subcategories = c.Subcategories.Select(s => new SubcategoryDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    CategoryId = s.CategoryId
                })
            }).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public async Task<CategoryDTO> GetCategoryById(string id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);

            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Subcategories = category.Subcategories.Select(s => new SubcategoryDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    CategoryId = s.CategoryId
                })
            };
        }

        public async Task<IEnumerable<SubcategoryDTO>> GetSubcategories()
        {
            var subcategories = await _unitOfWork.SubcategoryRepository.GetAsync();

            return subcategories.Select(s => new SubcategoryDTO
            {
                Id = s.Id,
                Name = s.Name,
                CategoryId = s.CategoryId
            });
        }

        public async Task<IEnumerable<SubcategoryDTO>> GetSubcategories(string name, int page, int pageSize)
        {
            var filteredSubcategories = await _unitOfWork.SubcategoryRepository.GetAsync(
                filter: s => s.Name.ToLower().Contains(name.ToLower()),
                orderBy: q => q.OrderBy(s => s.Name));

            return filteredSubcategories.Select(s => new SubcategoryDTO
            {
                Id = s.Id,
                Name = s.Name,
                CategoryId = s.CategoryId
            }).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public async Task<SubcategoryDTO> GetSubcategoryById(string id)
        {
            var subcategory = await _unitOfWork.SubcategoryRepository.GetByIdAsync(id);

            return new SubcategoryDTO
            {
                Id = subcategory.Id,
                Name = subcategory.Name,
                CategoryId = subcategory.CategoryId
            };
        }

        public async Task UpdateCategory(CategoryDTO categoryModel)
        {
            var category = new Category
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name
            };
            _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.SaveAsync();
        }

        public Task UpdateSubcategory(SubcategoryDTO subcategoryModel)
        {
            var subcategory = new Subcategory
            {
                Id = subcategoryModel.Id,
                Name = subcategoryModel.Name,
                CategoryId = subcategoryModel.CategoryId
            };
            _unitOfWork.SubcategoryRepository.Update(subcategory);
            return _unitOfWork.SaveAsync();
        }
    }
}
