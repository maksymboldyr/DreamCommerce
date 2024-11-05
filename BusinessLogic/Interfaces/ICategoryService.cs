using BusinessLogic.DTO.Catalogue;

namespace BusinessLogic.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<(IEnumerable<CategoryDTO>, int)> GetCategoriesWithCount(string name, int page, int pageSize, string sortField, string sortOrder);
        Task<CategoryDTO> GetCategoryById(string id);
        Task CreateCategory(CategoryDTO categoryDto);
        Task UpdateCategory(CategoryDTO categoryModel);
        Task DeleteCategory(string id);


        Task<IEnumerable<SubcategoryDTO>> GetSubcategories();
        Task<(IEnumerable<SubcategoryDTO>, int)> GetSubcategoriesWithCount(string name, int page, int pageSize, string sortField, string sortOrder);
        Task<SubcategoryDTO> GetSubcategoryById(string id);
        Task CreateSubcategory(SubcategoryDTO subcategoryModel);
        Task UpdateSubcategory(SubcategoryDTO subcategoryModel);
        Task DeleteSubcategory(string id);
    }
}
