namespace API.Models;

/// <summary>
/// Represents the model for uploading product images.
/// </summary>
public class ProductImgUploadModel
{
    /// <summary>
    /// Id of the product the image belongs to.
    /// </summary>
    public required string ProductId { get; set; }

    /// <summary>
    /// Image file to upload.
    /// </summary>
    public required IFormFile Image { get; set; }
}
