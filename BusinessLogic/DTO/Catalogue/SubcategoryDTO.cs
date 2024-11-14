namespace BusinessLogic.DTO.Catalogue;

/// <summary>
/// Class representing <see cref="DataAccess.Entities.Subcategory"/> data transfer object
/// </summary>
public class SubcategoryDto
{
    /// <summary>
    /// Subcategory id
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Subcategory name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Id of the category to which the subcategory belongs
    /// </summary>
    public string CategoryId { get; set; }

    /// <summary>
    /// Name of the category to which the subcategory belongs
    /// </summary>
    public string? CategoryName { get; set; }
}
