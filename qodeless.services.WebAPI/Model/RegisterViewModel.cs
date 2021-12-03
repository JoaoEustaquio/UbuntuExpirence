using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qodeless.services.WebApi.Model
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
        public List<ClaimViewModel> Claims { get; set; }
    }
}
