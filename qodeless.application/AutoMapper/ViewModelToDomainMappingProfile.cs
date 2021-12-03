using AutoMapper;
using qodeless.application.ViewModels;
using qodeless.domain.Entities;

namespace qodeless.application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AccountViewModel,Account>();
        }
    }
}
