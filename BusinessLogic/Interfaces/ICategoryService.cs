using BusinessLogic.DTO.Catalogue;

namespace BusinessLogic.Interfaces;

/// <summary>
/// Interface for category service. Defines methods for managing categories and subcategories.
/// </summary>
public interface ICategoryService
{
    #region Category
    /// <summary>
    /// Gets all categories.
    /// </summary>
    /// <returns>Collection of <see cref="CategoryDto"/> objects.</returns>
    Task<IEnumerable<CategoryDto>> GetCategories();

    /// <summary>
    /// Gets categories by given filter with pagination and sorting.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <param name="sortField"></param>
    /// <param name="sortOrder"></param>
    /// <returns> Filtered, ordered and paginated collection of <see cref="CategoryDto"/> objects and total count of categories.</returns>
    Task<(IEnumerable<CategoryDto>, int)> GetCategoriesWithCount(string name, int page, int pageSize, string sortField, string sortOrder);

    /// <summary>
    /// Gets category by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns><see cref="CategoryDto"/> object.</returns>
    Task<CategoryDto> GetCategoryById(string id);

    /// <summary>
    /// Creates new category.
    /// </summary>
    /// <param name="categoryDto"></param>
    Task CreateCategory(CategoryDto categoryDto);

    /// <summary>
    /// Updates category.
    /// </summary>
    /// <param name="categoryModel"></param>
    /// <returns></returns>
    Task UpdateCategory(CategoryDto categoryModel);

    /// <summary>
    /// Deletes category by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteCategory(string id);
    #endregion

    #region Subcategory
    /// <summary>
    /// Gets all subcategories.
    /// </summary>
    /// <returns>Collection of <see cref="SubcategoryDto"/> objects.</returns>
    Task<IEnumerable<SubcategoryDto>> GetSubcategories();

    /// <summary>
    /// Gets subcategories by given filter with pagination and sorting.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <param name="sortField"></param>
    /// <param name="sortOrder"></param>
    /// <returns>Filtered, ordered and paginated collection of <see cref="SubcategoryDto"/> objects and total count of subcategories.</returns>
    Task<(IEnumerable<SubcategoryDto>, int)> GetSubcategoriesWithCount(string name, int page, int pageSize, string sortField, string sortOrder);

    /// <summary>
    /// Gets subcategory by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns><see cref="SubcategoryDto"/> object.</returns>
    Task<SubcategoryDto> GetSubcategoryById(string id);

    /// <summary>
    /// Creates new subcategory.
    /// </summary>
    /// <param name="subcategoryModel"></param>
    Task CreateSubcategory(SubcategoryDto subcategoryModel);

    /// <summary>
    /// Updates subcategory.
    /// </summary>
    /// <param name="subcategoryModel"></param>
    Task UpdateSubcategory(SubcategoryDto subcategoryModel);

    /// <summary>
    /// Deletes subcategory by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteSubcategory(string id);
    #endregion
}
