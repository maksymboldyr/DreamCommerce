using API.Models;
using BusinessLogic.DTO.Catalogue;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // GET: api/Categories
    [HttpGet]
    [Route("All")]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
    {
        try
        {
            var categories = await _categoryService.GetCategories();
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/Categories
    [HttpGet]
    public async Task<ActionResult<TableViewModel<CategoryDto>>> GetCategories([FromQuery] string filter = "", [FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string sortField = "Name", [FromQuery] string sortOrder = "asc")
    {
        try
        {
            var categories = await _categoryService.GetCategoriesWithCount(filter, page, pageSize, sortField, sortOrder);
            var tableViewModel = new TableViewModel<CategoryDto>
            {
                Data = categories.Item1,
                TotalCount = categories.Item2,
            };
            return Ok(tableViewModel);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/Categories/{id}
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

    // POST: api/Categories
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryDTO)
    {
        try
        {
            await _categoryService.CreateCategory(categoryDTO);
            return StatusCode(201, "Category created successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // PUT: api/Categories
    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateCategory([FromBody] CategoryDto categoryModel)
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

    // DELETE: api/Categories/{id}
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
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
