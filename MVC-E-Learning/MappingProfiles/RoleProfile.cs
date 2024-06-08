using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MVC_E_Learning.ViewModels;

namespace MVC_E_Learning.MappingProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<IdentityRole , RoleViewModel>().ReverseMap();
        }
    }
}
