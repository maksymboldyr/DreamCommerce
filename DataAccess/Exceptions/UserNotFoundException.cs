using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Exceptions;

/// <summary>
/// Exception thrown when a user is not found.
/// </summary>
public class UserNotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <seealso cref="UserNotFoundException"/> class.
    /// </summary>
    /// <param name="id"></param>
    public UserNotFoundException(string id)
        : base($"User with ID '{id}' not found.") { }
}
