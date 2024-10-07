using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Repository;
using Mapster;

namespace BusinessLogic.Services.Domain
{
    public class CategoryService(
        UnitOfWork unitOfWork,
        FilterBuilderService filterBuilderService,
        SortingService<Category> categorySortingService,
        SortingService<Subcategory> subcategorySortingService) : ICategoryService
    {
        public async Task CreateCategory(CategoryDTO categoryDto)
        {
            var category = categoryDto.Adapt<Category>();
            await unitOfWork.CategoryRepository.InsertAsync(category);
        }

        public async Task CreateSubcategory(SubcategoryDTO subcategoryModel)
        {
            var subcategory = subcategoryModel.Adapt<Subcategory>();
            await unitOfWork.SubcategoryRepository.InsertAsync(subcategory);
        }

        public async Task DeleteCategory(string id)
        {
            var subcategories = await unitOfWork.SubcategoryRepository.GetAsync(filter: s => s.CategoryId == id);
            foreach (var subcategory in subcategories)
            {
                await unitOfWork.SubcategoryRepository.DeleteAsync(subcategory.Id);
            }
            await unitOfWork.CategoryRepository.DeleteAsync(id);
        }

        public async Task DeleteSubcategory(string id)
        {
            await unitOfWork.SubcategoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categories = await unitOfWork.CategoryRepository.GetAsync();
            return categories.Adapt<IEnumerable<CategoryDTO>>();
        }

        public async Task<(IEnumerable<CategoryDTO>, int)> GetCategoriesWithCount(string filter, int page, int pageSize, string sortField, string sortOrder)
        {
            var filterExpression = filterBuilderService.BuildFilter<Category>(filter);
            var sortingExpression = categorySortingService.GetSortExpression(sortField, sortOrder);

            var filteredCategories = await unitOfWork.CategoryRepository.GetAsync(
                filter: filterExpression,
                orderBy: sortingExpression,
                includeProperties: "Subcategories");

            var result = filteredCategories
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Adapt<IEnumerable<CategoryDTO>>();

            return (result, filteredCategories.Count());
        }

        public async Task<CategoryDTO> GetCategoryById(string id)
        {
            var category = await unitOfWork.CategoryRepository.GetByIdAsync(id);
            return category.Adapt<CategoryDTO>();
        }

        public async Task<IEnumerable<SubcategoryDTO>> GetSubcategories()
        {
            var subcategories = await unitOfWork.SubcategoryRepository.GetAsync();
            return subcategories.Adapt<IEnumerable<SubcategoryDTO>>();
        }

        public async Task<(IEnumerable<SubcategoryDTO>, int)> GetSubcategoriesWithCount(string filter, int page, int pageSize, string sortField, string sortOrder)
        {
            var filterExpression = filterBuilderService.BuildFilter<Subcategory>(filter);
            var sortingExpression = subcategorySortingService.GetSortExpression(sortField, sortOrder);

            var filteredSubcategories = await unitOfWork.SubcategoryRepository.GetAsync(
                filter: filterExpression,
                orderBy: sortingExpression,
                includeProperties: "Category");

            var result = filteredSubcategories
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Adapt<IEnumerable<SubcategoryDTO>>();

            return (result, filteredSubcategories.Count());
        }

        public async Task<SubcategoryDTO> GetSubcategoryById(string id)
        {
            var subcategory = await unitOfWork.SubcategoryRepository.GetByIdAsync(id);
            return subcategory.Adapt<SubcategoryDTO>();
        }

        public async Task UpdateCategory(CategoryDTO categoryModel)
        {
            var category = categoryModel.Adapt<Category>();
            unitOfWork.CategoryRepository.Update(category);
            await Task.CompletedTask;
        }

        public Task UpdateSubcategory(SubcategoryDTO subcategoryModel)
        {
            var subcategory = subcategoryModel.Adapt<Subcategory>();
            unitOfWork.SubcategoryRepository.Update(subcategory);
            return Task.CompletedTask;
        }
    }
}
