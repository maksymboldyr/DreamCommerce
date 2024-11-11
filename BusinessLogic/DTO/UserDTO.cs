namespace BusinessLogic.DTO;

/// <summary>
/// Represents a user data transfer object.
/// </summary>
public class UserDto
{
    /// <summary>
    /// The user's unique identifier.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// The user's email address.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// The user's first name.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// The user's last name.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// The user's phone number.
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// The user's address.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// The user's roles.
    /// </summary>
    public IEnumerable<string>? Roles { get; set; }
}
