using AutoMapper;
using DAL.Models;
using MVC_E_Learning.ViewModels;

namespace MVC_E_Learning.MappingProfiles
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<InstructorVM , AppUser>().ReverseMap();
        }
    }
}
