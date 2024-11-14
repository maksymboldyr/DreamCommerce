namespace BusinessLogic.DTO;

/// <summary>
/// Represents user data that is returned to the client.
/// </summary>
public class UserDataDto
{
    /// <summary>
    /// Unique identifier of the user.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// User's email address.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// User's first and last name.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// User's last name.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// User's phone number.
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// User's zip code.
    /// </summary>
    public string ZipCode { get; set; }

    /// <summary>
    /// User's country.
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// User's city.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// User's street.
    /// </summary>
    public string Street { get; set; }

    /// <summary>
    /// User's building number.
    /// </summary>
    public string Building { get; set; }

    /// <summary>
    /// User's apartment number.
    /// </summary>
    public string Apartment { get; set; }
}
