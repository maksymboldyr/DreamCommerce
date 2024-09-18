using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] string name = "", [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var categories = await _categoryService.GetCategories(name, page, pageSize);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Category/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(string id)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(id);

                if (category == null)
                {
                    return NotFound("Category not found.");
                }

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Category
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] string name)
        {
            try
            {
                await _categoryService.CreateCategory(name);
                return StatusCode(201, "Category created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Category
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryDTO categoryModel)
        {
            try
            {
                await _categoryService.UpdateCategory(categoryModel);
                return Ok("Category updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Category/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            try
            {
                await _categoryService.DeleteCategory(id);
                return Ok("Category deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
