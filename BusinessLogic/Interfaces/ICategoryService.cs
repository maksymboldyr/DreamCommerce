using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<IEnumerable<CategoryDTO>> GetCategories(string name, int page, int pageSize);
        Task<CategoryDTO> GetCategoryById(string id);
        Task CreateCategory(string name);
        Task UpdateCategory(CategoryDTO categoryModel);
        Task DeleteCategory(string id);


        Task<IEnumerable<SubcategoryDTO>> GetSubcategories();
        Task<IEnumerable<SubcategoryDTO>> GetSubcategories(string name, int page, int pageSize);
        Task<SubcategoryDTO> GetSubcategoryById(string id);
        Task CreateSubcategory(SubcategoryDTO subcategoryModel);
        Task UpdateSubcategory(SubcategoryDTO subcategoryModel);
        Task DeleteSubcategory(string id);
    }
}
