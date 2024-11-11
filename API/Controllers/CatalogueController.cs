using BusinessLogic.DTO.Catalogue;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogueController(
    IProductService productService, 
    ICategoryService categoryService) : ControllerBase
{
    //GET api/Catalogue/{subcategoryName}
    [HttpGet("search/{subcategoryName}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsBySubcategoryName(string subcategoryName)
    {
        try
        {
            var subcategories = await categoryService.GetSubcategories();
            var subcategory = subcategories.FirstOrDefault(s => s.Name == subcategoryName);

            if (subcategory == null)
            {
                return NotFound();
            }

            var products = await productService.GetProducts();
            var productsBySubcategory = products.Where(p => p.SubcategoryId == subcategory.Id);

            return Ok(productsBySubcategory);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/Catalogue/{productId}
    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProduct(string productId)
    {
        try
        {
            var product = await productService.GetProductById(productId);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
