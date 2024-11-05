using API.Models;
using BusinessLogic.DTO.Catalogue;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogueController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string rootPath;

        public CatalogueController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
            rootPath = _webHostEnvironment.WebRootPath;
        }

        //GET api/Catalogue/{subcategoryName}
        [HttpGet("search/{subcategoryName}")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsBySubcategoryName(string subcategoryName)
        {
            try
            {
                var subcategories = await _categoryService.GetSubcategories();
                var subcategory = subcategories.FirstOrDefault(s => s.Name == subcategoryName);

                if (subcategory == null)
                {
                    return NotFound();
                }

                var products = await _productService.GetProducts();
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
                var product = await _productService.GetProductById(productId);
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
}
