using BLL.ViewModels;
using DAL.Models;
using MVC_E_Learning.ViewModels;

namespace BLL.Interfaces
{
    public interface ICourseRepository 
    {
        Task<List<Course>> GetCourses();
        Task AddCourse(Course course);
        Task<Course> GetCourseById(int id);
        void EditCourse(Course model);
        void DeleteCourse(int id);
        void DeleteAssignedCourse(int id);
        Task AssignCourseToInstructor(InstructorCourseVM model);
        Task<List<InstructorCourseVM>> GetAssignedCoursesAndInstructor();
        int GetCoursesCount();



    }
}
