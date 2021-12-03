using AutoMapper;
using qodeless.domain.Entities;
using qodeless.domain.Interfaces.Repositories;
using qodeless.Infra.CrossCutting.Identity.Data;
using qodeless.presentation.UI.Web.Controllers;
using qodeless.presentation.UI.Web.Extensions;
using qodeless.presentation.UI.Web.Models;
using qodeless.presentation.WebApp.Models;

namespace qodeless.presentation.WebApp.Controllers
{
    public class GroupController : BaseController<Group, GroupViewModel>
    {
        private readonly IGroupRepository _GroupRepository;

        public GroupController(IGroupRepository groupRepository, ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
            _GroupRepository = groupRepository;
        }

        public override void BuildForm(GroupViewModel vm)
        {
            @ViewBag.Form = new UbuntuBuilder()
                 .SetController(this)
                 .SetInfo("Grupo", "Informações Básicas")
                 .AddRowStart()
                         .InputText("CPF", vm.Code, 2)
                         .InputText("Nome", vm.Name, 4)
                 .AddRowEnd()
             .Build(vm);
        }

        public override bool Validate(GroupViewModel vm)
        {
            ValidateInit(vm.Id);

            return ValidateBase();
        }

        public override DeleteViewModel ValidateDelete(Group vm)
        {
            return new DeleteViewModel()
            {
                Id = vm.Id,
                Name = vm.Code,
                Description = vm.Name
            };
        }

        public override bool SaveData(GroupViewModel vm)
        {
            var group = new Group(vm.Id)
            {
                Code = vm.Code,
                AcceptanceCriteria = vm.AcceptanceCriteria,
                Name = vm.Name
            };

            return _GroupRepository.Save(group);
        }

        public override void LoadViewBags()
        {
        }
    }
}
