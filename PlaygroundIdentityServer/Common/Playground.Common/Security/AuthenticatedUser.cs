using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Common.Security
{
    public class AuthenticatedUser : ClaimsPrincipal
    {
        public static AuthenticatedUser Get(ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

    }
}
