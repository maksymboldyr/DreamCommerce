using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string id)
            : base($"User with ID '{id}' not found.") { }
    }
}
