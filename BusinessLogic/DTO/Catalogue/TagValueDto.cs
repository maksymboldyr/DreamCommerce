using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO.Catalogue
{
    public class TagValueDto
    {
        public string? Id { get; set; }
        public string TagId { get; set; }
        public string? TagName { get; set; }
        public string Value { get; set; }
        public string? SubcategoryName { get; set; }
    }
}
