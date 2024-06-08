using AutoMapper;
using DAL.Models;
using MVC_E_Learning.ViewModels;

namespace MVC_E_Learning.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserViewModel>();
            CreateMap<UserViewModel,AppUser>();
        }
    }
}
