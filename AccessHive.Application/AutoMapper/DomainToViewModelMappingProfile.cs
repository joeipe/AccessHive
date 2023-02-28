using AccessHive.Read.Domain;
using AccessHive.ViewModels;
using AutoMapper;

namespace AccessHive.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Role, RoleVM>();
        }
    }
}