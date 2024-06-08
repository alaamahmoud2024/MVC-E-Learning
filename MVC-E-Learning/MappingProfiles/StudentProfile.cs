using AutoMapper;
using DAL.Models;
using MVC_E_Learning.ViewModels;

namespace MVC_E_Learning.MappingProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentVM , AppUser>().ReverseMap();
            
        }
    }
}
