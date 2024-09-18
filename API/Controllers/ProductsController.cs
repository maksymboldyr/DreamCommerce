using API.Models;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(IProductService productService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts([FromQuery] string name = "", [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var products = await _productService.GetProducts(name, page, pageSize);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(string id)
        {
            try
            {
                var product = await _productService.GetProductById(id);

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

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDTO product)
        {
            try
            {
                product.ImageUrl = Path.Combine(_webHostEnvironment.WebRootPath, @"images\NotFound.png");
                await _productService.CreateProduct(product);
                return StatusCode(201, "Product created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Products/upload-image
        [HttpPost("upload-image")]
        public async Task<ActionResult> UploadProductImage([FromForm] ProductImgUploadModel model)
        {
            try
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                var product = await _productService.GetProductById(model.ProductId);

                // Check if product is found
                if (product == null)
                {
                    return NotFound("Product not found.");
                }

                // Update product properties
                if (model.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Image.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");
                    string fullPath = Path.Combine(productPath, fileName);

                    if (!Directory.Exists(productPath))
                    {
                        Directory.CreateDirectory(productPath);
                    }

                    using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(fileStream);
                    }

                    product.ImageUrl = fullPath; // Update existing product
                }
                else
                {
                    product.ImageUrl = Path.Combine(wwwRootPath, @"images\NotFound.png");
                }

                // Save changes to the product entity
                await _productService.UpdateProduct(product);
                return Ok("Image uploaded successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        // PUT: api/Products/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(string id, [FromBody] ProductDTO product)
        {
            if (id != product.Id)
            {
                return BadRequest("Product ID mismatch");
            }

            try
            {
                await _productService.UpdateProduct(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Products/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            try
            {
                await _productService.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
