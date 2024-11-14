using BusinessLogic.DTO.Catalogue;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Repository;
using Mapster;

namespace BusinessLogic.Services.Domain;

/// <summary>
/// Service for managing categories and subcategories.
/// </summary>
public class CategoryService(
    UnitOfWork unitOfWork,
    FilterBuilderService filterBuilderService,
    SortingService<Category> categorySortingService,
    SortingService<Subcategory> subcategorySortingService) : ICategoryService
{
    /// <summary>
    /// Creates a new category.
    /// </summary>
    /// <param name="categoryDto">The category data transfer object.</param>
    public async Task CreateCategory(CategoryDto categoryDto)
    {
        var category = categoryDto.Adapt<Category>();
        await unitOfWork.CategoryRepository.InsertAsync(category);
    }

    /// <summary>
    /// Creates a new subcategory.
    /// </summary>
    /// <param name="subcategoryModel">The subcategory data transfer object.</param>
    public async Task CreateSubcategory(SubcategoryDto subcategoryModel)
    {
        var subcategory = subcategoryModel.Adapt<Subcategory>();
        await unitOfWork.SubcategoryRepository.InsertAsync(subcategory);
    }

    /// <summary>
    /// Deletes a category by its identifier.
    /// </summary>
    /// <param name="id">The category identifier.</param>
    public async Task DeleteCategory(string id)
    {
        var subcategories = await unitOfWork.SubcategoryRepository.GetAsync(filter: s => s.CategoryId == id);
        foreach (var subcategory in subcategories)
        {
            await unitOfWork.SubcategoryRepository.DeleteAsync(subcategory.Id);
        }
        await unitOfWork.CategoryRepository.DeleteAsync(id);
    }

    /// <summary>
    /// Deletes a subcategory by its identifier.
    /// </summary>
    /// <param name="id">The subcategory identifier.</param>
    public async Task DeleteSubcategory(string id)
    {
        await unitOfWork.SubcategoryRepository.DeleteAsync(id);
    }

    /// <summary>
    /// Gets all categories.
    /// </summary>
    /// <returns>Collection of <see cref="CategoryDto"/> objects.</returns>
    public async Task<IEnumerable<CategoryDto>> GetCategories()
    {
        var categories = await unitOfWork.CategoryRepository.GetAsync();
        return categories.Adapt<IEnumerable<CategoryDto>>();
    }

    /// <summary>
    /// Gets categories by given filter with pagination and sorting.
    /// </summary>
    /// <param name="filter">The filter string.</param>
    /// <param name="page">The page number.</param>
    /// <param name="pageSize">The page size.</param>
    /// <param name="sortField">The field to sort by.</param>
    /// <param name="sortOrder">The sort order (asc/desc).</param>
    /// <returns>Filtered, ordered and paginated collection of <see cref="CategoryDto"/> objects and total count of filtered out categories, before pagination is applied.</returns>
    public async Task<(IEnumerable<CategoryDto>, int)> GetCategoriesWithCount(string filter, int page, int pageSize, string sortField, string sortOrder)
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
            .Adapt<IEnumerable<CategoryDto>>();

        return (result, filteredCategories.Count());
    }

    /// <summary>
    /// Gets category by id.
    /// </summary>
    /// <param name="id">The category identifier.</param>
    /// <returns><see cref="CategoryDto"/> object.</returns>
    public async Task<CategoryDto> GetCategoryById(string id)
    {
        var category = await unitOfWork.CategoryRepository.GetByIdAsync(id);
        return category.Adapt<CategoryDto>();
    }

    /// <summary>
    /// Gets all subcategories.
    /// </summary>
    /// <returns>Collection of <see cref="SubcategoryDto"/> objects.</returns>
    public async Task<IEnumerable<SubcategoryDto>> GetSubcategories()
    {
        var subcategories = await unitOfWork.SubcategoryRepository.GetAsync();
        return subcategories.Adapt<IEnumerable<SubcategoryDto>>();
    }

    /// <summary>
    /// Gets subcategories by given filter with pagination and sorting.
    /// </summary>
    /// <param name="filter">The filter string.</param>
    /// <param name="page">The page number.</param>
    /// <param name="pageSize">The page size.</param>
    /// <param name="sortField">The field to sort by.</param>
    /// <param name="sortOrder">The sort order (asc/desc).</param>
    /// <returns>Filtered, ordered and paginated collection of <see cref="SubcategoryDto"/> objects and total count of filtered subcategories, before pagination is applied.</returns>
    public async Task<(IEnumerable<SubcategoryDto>, int)> GetSubcategoriesWithCount(string filter, int page, int pageSize, string sortField, string sortOrder)
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
            .Adapt<IEnumerable<SubcategoryDto>>();

        return (result, filteredSubcategories.Count());
    }

    /// <summary>
    /// Gets subcategory by id.
    /// </summary>
    /// <param name="id">The subcategory identifier.</param>
    /// <returns><see cref="SubcategoryDto"/> object.</returns>
    public async Task<SubcategoryDto> GetSubcategoryById(string id)
    {
        var subcategory = await unitOfWork.SubcategoryRepository.GetByIdAsync(id);
        return subcategory.Adapt<SubcategoryDto>();
    }

    /// <summary>
    /// Updates a category.
    /// </summary>
    /// <param name="categoryModel">The category data transfer object.</param>
    public async Task UpdateCategory(CategoryDto categoryModel)
    {
        var category = categoryModel.Adapt<Category>();
        unitOfWork.CategoryRepository.Update(category);
        await Task.CompletedTask;
    }

    /// <summary>
    /// Updates a subcategory.
    /// </summary>
    /// <param name="subcategoryModel">The subcategory data transfer object.</param>
    public Task UpdateSubcategory(SubcategoryDto subcategoryModel)
    {
        var subcategory = subcategoryModel.Adapt<Subcategory>();
        unitOfWork.SubcategoryRepository.Update(subcategory);
        return Task.CompletedTask;
    }
}
