using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class ProductTag
    {
        [ForeignKey("Product")]
        public string ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Tag")]
        public string TagId { get; set; }
        public Tag Tag { get; set; }

        [ForeignKey("TagValue")]
        public string TagValueId { get; set; }
        public TagValue TagValue { get; set; }
    }
}
