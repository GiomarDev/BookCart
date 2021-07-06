using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Agregarmos la dependencia Autorization
using Microsoft.AspNetCore.Authorization;

namespace BookCart.Models
{
    public class Polices
    {
        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                .RequireRole(UserRoles.Admin).Build();
        }

        public static AuthorizationPolicy UserPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                    .RequireRole(UserRoles.User).Build();
        }
    }
}
