namespace BusinessLogic.DTO.Auth;

/// <summary>
/// Result of a login operation.
/// </summary>
public class LoginResponseDto
{
    /// <summary>
    /// Access token returned on successful login.
    /// </summary>
    public string Token { get; set; }
}
