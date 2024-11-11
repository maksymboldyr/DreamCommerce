namespace BusinessLogic.DTO.Auth;

/// <summary>
/// Data transfer object for logging in.
/// </summary>
public class LoginDto
{
    /// <summary>
    /// User's email.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// User's password.
    /// </summary>
    public string Password { get; set; }
}
