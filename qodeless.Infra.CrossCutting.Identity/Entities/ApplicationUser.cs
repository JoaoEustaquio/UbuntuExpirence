using Microsoft.AspNetCore.Identity;
using System;

namespace qodeless.Infra.CrossCutting.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        #region Custom properties
        public DateTime CreationDate { get; set; }
        public bool Enabled { get; set; }
        #endregion
    }
}
