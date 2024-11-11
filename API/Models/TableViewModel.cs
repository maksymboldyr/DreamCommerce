namespace API.Models;

/// <summary>
/// Contains the properties of a table to be displayed in client.
/// </summary>
/// <typeparam name="T"></typeparam>
public class TableViewModel<T> where T : class
{
    /// <summary>
    /// Total number of items in the table with the applied filter.
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Paginated data to be displayed in the table.
    /// </summary>
    public IEnumerable<T> Data { get; set; }
}
