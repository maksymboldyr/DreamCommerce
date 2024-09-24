namespace API.Models
{
    public class TableViewModel<T> where T : class
    {
        public int TotalCount { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
