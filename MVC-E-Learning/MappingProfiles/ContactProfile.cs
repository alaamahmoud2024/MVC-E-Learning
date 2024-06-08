using AutoMapper;
using BL.ViewModels;
using DAL.Models;
using MVC_E_Learning.ViewModels;

namespace MVC_E_Learning.MappingProfiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactVM, Contact>().ReverseMap();
            CreateMap<Topic, TopicVM>().ReverseMap();
            CreateMap<Assignment, AssignmentVM>().ReverseMap();
        }
    }
}
