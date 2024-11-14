using API.Models;
using BusinessLogic.DTO.Catalogue;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(
    IProductService productService, 
    IWebHostEnvironment webHostEnvironment) : ControllerBase
{
    private readonly string rootPath = webHostEnvironment.WebRootPath;

    // GET: api/Products
    [HttpGet]
    public async Task<ActionResult<TableViewModel<ProductDto>>> GetProducts([FromQuery] string name = "", [FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string sortField = "Name", [FromQuery] string sortOrder = "asc")
    {
        try
        {
            var products = await productService.GetProductsWithCount(name, page, pageSize, sortField, sortOrder);



            var tableViewModel = new TableViewModel<ProductDto>
            {
                Data = products.Item1,
                TotalCount = products.Item2,
            };

            
            return Ok(tableViewModel);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/Products/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProductById(string id)
    {
        try
        {
            var product = await productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            //Chcek if image is exist at the path
            string fullPath = Path.Combine(rootPath, product.ImageUrl);
            if (!System.IO.File.Exists(fullPath))
            {
                product.ImageUrl = @"images/NotFound.png";
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
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> CreateProduct([FromBody] ProductDto product)
    {
        try
        {
            product.ImageUrl = @"images/NotFound.png";
            await productService.CreateProduct(product);
            return StatusCode(201, "Product created successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // POST: api/Products/upload-image
    [HttpPost("upload-image")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> UploadProductImage([FromForm] ProductImgUploadModel model)
    {
        try
        {
            var product = await productService.GetProductById(model.ProductId);

            // Check if product is found
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            // Update product properties
            if (model.Image != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Image.FileName);
                string imageUrl = Path.Combine(@"images\product", fileName);
                string productPath = Path.Combine(rootPath, @"images\product");
                string fullPath = Path.Combine(rootPath, imageUrl);

                if (!Directory.Exists(productPath))
                {
                    Directory.CreateDirectory(productPath);
                }

                using (FileStream fileStream = new(fullPath, FileMode.Create))
                {
                    await model.Image.CopyToAsync(fileStream);
                }

                product.ImageUrl = imageUrl; // Update existing product
            }
            else
            {
                product.ImageUrl = @"images/NotFound.png";
            }

            // Save changes to the product entity
            await productService.UpdateProduct(product);
            return Ok("Image uploaded successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }


    // PUT: api/Products/{id}
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> UpdateProduct(string id, [FromBody] ProductDto product)
    {
        if (id != product.Id)
        {
            return BadRequest("Product ID mismatch");
        }

        try
        {
            await productService.UpdateProduct(product);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // DELETE: api/Products/{id}
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteProduct(string id)
    {
        try
        {
            await productService.DeleteProduct(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
