using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class InstructorCourseVM
    {
        public int Id{ get; set; }
        public int CourseId{ get; set; }
        public string? CourseName{ get; set; }
        public string? InstructorName { get; set; }
        public List<Course>? Courses{ get; set; }
        public string InstructorId{ get; set; }
        public List<Instructor>? Instructors { get; set; }
    }
}
