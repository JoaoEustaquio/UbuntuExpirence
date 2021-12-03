using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jll.portal_api.services.WebAPI.Extensions
{
    public static class RoleExtension
    {
        public static bool IsValidRole(this string role)
        {
            switch (role.ToLower())
            {
                case Role.MANAGER:
                    return true;
                    break;
                case Role.DEVELOPER:
                    return true;
                    break;
                case Role.COMMON_USER:
                    return true;
                    break;
            }
            return false;
        }
    }
}
