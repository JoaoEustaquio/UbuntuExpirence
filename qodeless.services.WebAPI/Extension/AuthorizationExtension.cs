using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qodeless.services.WebApi.Extension
{
    public static class AuthorizationExtension
    {
        public static IServiceCollection AddJwtAuthorization(this IServiceCollection services)
        {
            return services.AddAuthorization(options =>
            {
                //login eliel para testar essa policy
                options.AddPolicy(Policy.REGISTER_USER, builder =>
                {
                    builder.RequireAuthenticatedUser();
                    builder.RequireRole(Role.MANAGER);
                    builder.RequireClaim(ClaimType.MANAGER_CLAIMS, ClaimValue.CREATE);
                });
                //login felipe para testar essa policy
                options.AddPolicy(Policy.DEVELOPER_CREATE, builder =>
                {
                    builder.RequireAuthenticatedUser();
                    builder.RequireRole(Role.DEVELOPER);
                    builder.RequireClaim(ClaimType.DEVELOPER_CLAIMS, ClaimValue.CREATE);
                });

                options.AddPolicy(Policy.GROUP_CREATE, builder =>
                {
                    builder.RequireAuthenticatedUser();
                    builder.RequireRole(Role.MANAGER);
                    builder.RequireClaim(ClaimType.DEVELOPER_CLAIMS, ClaimValue.CREATE);
                });
            });
        }
    }
}
