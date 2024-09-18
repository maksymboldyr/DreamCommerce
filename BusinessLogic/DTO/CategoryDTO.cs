namespace BusinessLogic.DTO
{
    public class CategoryDTO
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SubcategoryDTO>? Subcategories { get; set; }
    }
}
