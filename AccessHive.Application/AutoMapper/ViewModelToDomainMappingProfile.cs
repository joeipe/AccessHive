using AccessHive.ViewModels;
using AccessHive.Write.Domain;
using AutoMapper;

namespace AccessHive.Application.AutoMapper
{
    internal class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RoleVM, Role>();
        }
    }
}