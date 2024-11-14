namespace BusinessLogic.DTO.Auth;

/// <summary>
/// Class that represents a role in the system.
/// </summary>
public class RoleDto
{
    /// <summary>
    /// Identifier of the role.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Name of the role.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Description of the role.
    /// </summary>
    public string Description { get; set; }
}
