using qodeless.domain.Entities;

namespace qodeless.Infra.CrossCutting.Identity.DataModel
{
    public class UserDataModel : IUserDataModel
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string ClaimsType { get; set; }
        public string ClaimsValue { get; set; }
    }
}
