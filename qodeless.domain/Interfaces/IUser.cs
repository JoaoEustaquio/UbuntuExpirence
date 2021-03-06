using System.Collections.Generic;
using System.Security.Claims;

namespace qodeless.domain.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
