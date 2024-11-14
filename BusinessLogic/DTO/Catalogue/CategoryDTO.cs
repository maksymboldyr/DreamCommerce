namespace BusinessLogic.DTO.Catalogue;

/// <summary>
/// Represents a product <see cref="DataAccess.Entities.Category"/> data transfer object
/// </summary>
public class CategoryDto
{
    /// <summary>
    /// Id of the category
    /// </summary>
    public string? Id { get; set; }
    
    /// <summary>
    /// Category name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// List of <seealso cref="SubcategoryDto"/> related to the category
    /// </summary>
    public IEnumerable<SubcategoryDto>? Subcategories { get; set; }
}
