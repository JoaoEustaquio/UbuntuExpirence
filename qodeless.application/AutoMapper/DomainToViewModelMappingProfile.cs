using AutoMapper;
using qodeless.application.ViewModels;
using qodeless.domain.Entities;

namespace qodeless.application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Account, AccountViewModel>();
        }
    }
}
