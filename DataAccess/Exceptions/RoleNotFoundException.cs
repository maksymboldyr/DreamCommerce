namespace DataAccess.Exceptions;

/// <summary>
/// Exception thrown when a role is not found.
/// </summary>
public class RoleNotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <seealso cref="RoleNotFoundException"/> class.
    /// </summary>
    /// <param name="roleName"></param>
    public RoleNotFoundException(string roleName)
        : base($"Role '{roleName}' not found.") { }
}
