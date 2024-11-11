namespace BusinessLogic.DTO.Auth;

/// <summary>
/// Data transfer object for editing user roles.
/// </summary>
public class EditUserRolesDto
{
    /// <summary>
    /// Identifier of the user.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Name of the role.
    /// </summary>
    public string RoleName { get; set; }
}
