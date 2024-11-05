using API.Models;
using BusinessLogic.DTO.Catalogue;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public SubcategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Subcategory/All
        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<SubcategoryDTO>>> GetSubcategories()
        {
            try
            {
                var subcategories = await _categoryService.GetSubcategories();
                return Ok(subcategories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Subcategory
        [HttpGet]
        public async Task<ActionResult<TableViewModel<SubcategoryDTO>>> GetSubcategories([FromQuery] string filter = "", [FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string sortField = "Name", [FromQuery] string sortOrder = "asc")
        {
            try
            {
                var subcategories = await _categoryService.GetSubcategoriesWithCount(filter, page, pageSize, sortField, sortOrder);
                var tableViewModel = new TableViewModel<SubcategoryDTO>
                {
                    Data = subcategories.Item1,
                    TotalCount = subcategories.Item2,
                };
                return Ok(tableViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        // GET: api/Subcategory/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubcategory(string id)
        {
            try
            {
                var subcategory = await _categoryService.GetSubcategoryById(id);

                if (subcategory == null)
                {
                    return NotFound("Subcategory not found.");
                }

                return Ok(subcategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Subcategory
        [HttpPost]
        public async Task<IActionResult> CreateSubcategory([FromBody] SubcategoryDTO subcategory)
        {
            try
            {
                await _categoryService.CreateSubcategory(subcategory);
                return StatusCode(201, "Subcategory created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Subcategory
        [HttpPut]
        public async Task<IActionResult> UpdateSubcategory([FromBody] SubcategoryDTO subcategory)
        {
            try
            {
                await _categoryService.UpdateSubcategory(subcategory);
                return Ok("Subcategory updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Subcategory/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubcategory(string id)
        {
            try
            {
                await _categoryService.DeleteSubcategory(id);
                return Ok("Subcategory deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
