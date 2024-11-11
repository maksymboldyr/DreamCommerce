using API.Models;
using BusinessLogic.DTO.Catalogue;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubcategoriesController(ICategoryService categoryService) : ControllerBase
{
    // GET: api/Subcategory/All
    [HttpGet]
    [Route("All")]
    public async Task<ActionResult<IEnumerable<SubcategoryDto>>> GetSubcategories()
    {
        try
        {
            var subcategories = await categoryService.GetSubcategories();
            return Ok(subcategories);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/Subcategory
    [HttpGet]
    public async Task<ActionResult<TableViewModel<SubcategoryDto>>> GetSubcategories([FromQuery] string filter = "", [FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string sortField = "Name", [FromQuery] string sortOrder = "asc")
    {
        try
        {
            var subcategories = await categoryService.GetSubcategoriesWithCount(filter, page, pageSize, sortField, sortOrder);
            var tableViewModel = new TableViewModel<SubcategoryDto>
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
            var subcategory = await categoryService.GetSubcategoryById(id);

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
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateSubcategory([FromBody] SubcategoryDto subcategory)
    {
        try
        {
            await categoryService.CreateSubcategory(subcategory);
            return StatusCode(201, "Subcategory created successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // PUT: api/Subcategory
    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateSubcategory([FromBody] SubcategoryDto subcategory)
    {
        try
        {
            await categoryService.UpdateSubcategory(subcategory);
            return Ok("Subcategory updated successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // DELETE: api/Subcategory/{id}
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteSubcategory(string id)
    {
        try
        {
            await categoryService.DeleteSubcategory(id);
            return Ok("Subcategory deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
