namespace API.Models
{
    public class ProductImgUploadModel
    {
        public string ProductId { get; set; }
        public IFormFile Image { get; set; }
    }
}
