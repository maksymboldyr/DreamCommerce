namespace API.Models;

/// <summary>
/// Contains the properties of a product to be displayed in client.
/// </summary>
public class ProductViewModel
{
    /// <summary>
    /// Id of the product.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Name of the product.
    /// </summary>
    public string Name { get; set; } = "Empty Product Name";

    /// <summary>
    /// Description of the product.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Id of the category the product belongs to.
    /// </summary>
    public string CategoryId { get; set; } = string.Empty;

    /// <summary>
    /// Id of the subcategory the product belongs to.
    /// </summary>
    public string SubcategoryId { get; set; } = string.Empty;

    /// <summary>
    /// Name of the category the product belongs to.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Number of items in stock.
    /// </summary>
    public int Stock { get; set; }

    /// <summary>
    /// Discount percentage.
    /// </summary>
    public float Discount { get; set; }

    /// <summary>
    /// URL of the product's image.
    /// </summary>
    public IFormFile Image { get; set; } = null!;
}
