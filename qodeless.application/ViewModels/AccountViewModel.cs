using qodeless.domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace qodeless.application.ViewModels
{
    public class AccountViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CellPhone { get; set; }
        public EAccountStatus Status { get; set; }
    }
}
