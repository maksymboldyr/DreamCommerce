namespace BusinessLogic.DTO.Catalogue;

/// <summary>
/// Class representing a <see cref="DataAccess.Entities.Product"/> data transfer object
/// </summary>
public class ProductDto
{
    /// <summary>
    /// The product's unique identifier
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// The product's name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The product's description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Id of the category the product belongs to
    /// </summary>
    public string CategoryId { get; set; }

    /// <summary>
    /// Id of the subcategory the product belongs to
    /// </summary>
    public string SubcategoryId { get; set; }

    /// <summary>
    /// Name of the category the product belongs to
    /// </summary>
    public string? CategoryName { get; set; }

    /// <summary>
    /// Name of the subcategory the product belongs to
    /// </summary>
    public string? SubcategoryName { get; set; }

    /// <summary>
    /// Price of the product
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Number of items in stock
    /// </summary>
    public int Stock { get; set; }

    /// <summary>
    /// Discount percentage
    /// </summary>
    public float Discount { get; set; }

    /// <summary>
    /// URL of the product's image
    /// </summary>
    public string? ImageUrl { get; set; }
}
