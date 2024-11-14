namespace BusinessLogic.DTO;

/// <summary>
/// Represents an order data transfer object
/// </summary>
public class OrderDto
{
    /// <summary>
    /// The order's unique identifier
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// The user's unique identifier
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// The order's total price
    /// </summary>
    public decimal? TotalPrice { get; set; }

    /// <summary>
    /// Id of related address
    /// </summary>
    public string? AddressId { get; set; }

    /// <summary>
    /// Order creation date
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// <seealso cref="AddressDto"/> related to the order
    /// </summary>
    public AddressDto? Address { get; set; }

    /// <summary>
    /// List of <seealso cref="OrderDetailDto"/> related to the order"/>
    /// </summary>
    public List<OrderDetailDto>? OrderDetails { get; set; } = new List<OrderDetailDto>();

    /// <summary>
    /// Order status
    /// </summary>
    public string? Status { get; set; }

}
