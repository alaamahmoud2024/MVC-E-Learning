using AutoMapper;
using BLL.ViewModels;
using DAL.Models;
using MVC_E_Learning.ViewModels;

namespace MVC_E_Learning.MappingProfiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseVM , Course>();
            CreateMap<Course , CourseVM>();

            CreateMap<InstructorCourse , InstructorCourseVM>();
            CreateMap<InstructorCourseVM , InstructorCourse>();
        }
    }
}
