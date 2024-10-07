using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Exceptions
{
    public class RoleNotFoundException : Exception
    {
        public RoleNotFoundException(string roleName)
            : base($"Role '{roleName}' not found.") { }
    }
}
