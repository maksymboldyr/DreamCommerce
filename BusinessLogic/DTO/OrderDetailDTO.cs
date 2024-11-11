namespace BusinessLogic.DTO;

/// <summary>
/// Represents an <see cref="DataAccess.Entities.OrderDetail"/> data transfer object
/// </summary>
public class OrderDetailDto
{
    /// <summary>
    /// Id of the order detail
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Id of the related order
    /// </summary>
    public string? OrderId { get; set; }

    /// <summary>
    /// Id of the related product
    /// </summary>
    public string ProductId { get; set; }

    /// <summary>
    /// Name of the related product
    /// </summary>
    public string? ProductName { get; set; }

    /// <summary>
    /// Price of the related product
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// Quantity of the related product in the order
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Total price of the related product in the order
    /// </summary>
    public decimal TotalPrice { get; set; }
}
